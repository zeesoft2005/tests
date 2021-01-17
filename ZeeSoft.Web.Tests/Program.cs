using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ZeeSoft.Web.Tests
{
    class Program
    {
        static void TraceIt(TraceSource trace)
        {
            // Trace start
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            Trace.CorrelationManager.StartLogicalOperation("Main");
            trace.TraceEvent(TraceEventType.Start, 1000, "Program start.");
            trace.TraceEvent(TraceEventType.Information, 2000, "Hi, {0}", "Zeeshan");
            trace.TraceEvent(TraceEventType.Error,1,"Done");
            // Trace stop
            trace.TraceEvent(TraceEventType.Stop, 8000, "Program stop.");
            Trace.CorrelationManager.StopLogicalOperation();
            trace.Flush();
        }
        static void Main(string[] args)
        {
            TraceSource traceConsole = new TraceSource("HelloConsole");
            TraceSource traceXml = new TraceSource("HelloXML");
            TraceSource traceTextFile = new TraceSource("fileSource");
            TraceSource traceRollingFile = new TraceSource("RollingFileSource");
            var traceSQLDb = new TraceSource("SQLTraceSource");
            TraceIt(traceSQLDb);
            System.Console.ReadKey();
        }
    }
}
