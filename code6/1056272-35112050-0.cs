    public dynamic Post(Script script)
    {
        var console = (IConsole) new ScriptConsole();
        var logProvider = new ColoredConsoleLogProvider (LogLevel.Info, console);
    
        var builder = new ScriptServicesBuilder (console, logProvider);
    
        SetEngine (builder);
        var services = builder.Build ();
            
        var executor = (ScriptExecutor) services.Executor;
        executor.Initialize (Enumerable.Empty<string>(), Enumerable.Empty<IScriptPack>());
        executor.Execute ("HelloWorld.csx");
        _scriptcs.Executor.Terminate();
        if (result.CompileExceptionInfo != null)
           return new {error = result.CompileExceptionInfo.SourceException.Message};
        if (result.ExecuteExceptionInfo != null)
          return new { error = result.ExecuteExceptionInfo.SourceException.Message};
        return result.ReturnValue;
    }
