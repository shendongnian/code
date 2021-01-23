    JobHostConfiguration config = new JobHostConfiguration()
    {
        NameResolver = new ConfigNameResolver(),
    };
    
    // Demonstrates how the console trace level can be customized
    config.Tracing.ConsoleLevel = TraceLevel.Verbose;
    
    // Demonstrates how a custom TraceWriter can be plugged into the
    // host to capture all logging/traces.
    config.Tracing.Tracers.Add(new CustomTraceWriter(TraceLevel.Info));
    
    JobHost host = new JobHost(config);
    host.RunAndBlock();
