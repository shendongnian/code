    public dynamic Post(Script script)
    {
        ScriptServices scriptcs = new ScriptCsService().Root;
        scriptcs.Executor.Initialize(new[] { "System.Web" }, Enumerable.Empty<IScriptPack>());
        scriptcs.Executor.AddReferences(Assembly.GetExecutingAssembly());
        var console = (IConsole) new ScriptConsole();
        var logProvider = new ColoredConsoleLogProvider (LogLevel.Info, console);
    
        var builder = new ScriptServicesBuilder (console, logProvider);
    
        SetEngine (builder);
        var services = builder.Build ();
            
        var executor = (ScriptExecutor) services.Executor;
        executor.Initialize (Enumerable.Empty<string>(), Enumerable.Empty<IScriptPack>());
        var result = executor.Execute ("HelloWorld.csx");
        scriptcs.Executor.Terminate();
        if (result.CompileExceptionInfo != null)
           return new {error = result.CompileExceptionInfo.SourceException.Message};
        if (result.ExecuteExceptionInfo != null)
          return new { error = result.ExecuteExceptionInfo.SourceException.Message};
        return result.ReturnValue;
    }
