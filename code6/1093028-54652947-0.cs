    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.Diagnostics.Tracing;
    using Microsoft.Diagnostics.Tracing.Parsers;
    using Microsoft.Diagnostics.Tracing.Parsers.Tpl;
    using Microsoft.Diagnostics.Tracing.Session;
    ...
    Task.Run(() =>
    {
        using (var session = new TraceEventSession("TplCaptureSession"))
        {
            session.EnableProvider(TplEtwProviderTraceEventParser.ProviderGuid, TraceEventLevel.Always);
            var parser = new TplEtwProviderTraceEventParser(session.Source);
    parser.AddCallbackForEvent<TaskStartedArgs>(
                null,
                @event =>
                {
                    Console.WriteLine($"Task {@event.TaskID} started by {@event.OriginatingTaskID}");
                });
            parser.AddCallbackForEvent<TaskCompletedArgs>(
                null,
                @event =>
                {
                    Console.WriteLine($"Task {@event.TaskID} completed");
                });
            session.Source.Process();
        }
    });
