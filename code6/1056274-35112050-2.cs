    public dynamic RunScript()
    {
        var logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        var scriptServicesBuilder = new ScriptServicesBuilder(new ScriptConsole(), logger).
            LogLevel(LogLevel.Info).Cache(false).Repl(false).ScriptEngine<RoslynScriptEngine>();
        var scriptcs = scriptServicesBuilder.Build();
        scriptcs.Executor.Initialize(new[] { "System.Web" }, Enumerable.Empty<IScriptPack>());
        scriptcs.Executor.AddReferences(Assembly.GetExecutingAssembly());
        var result = scriptcs.Executor.Execute("HelloWorld.csx");
        scriptcs.Executor.Terminate();
        if (result.CompileExceptionInfo != null)
            return new { error = result.CompileExceptionInfo.SourceException.Message };
        if (result.ExecuteExceptionInfo != null)
            return new { error = result.ExecuteExceptionInfo.SourceException.Message };
        return result.ReturnValue;
    }
