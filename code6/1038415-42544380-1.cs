    public static class GenericLoggingExtensions
    {
        public static ILogger Log<TClass>(this TClass klass, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
            where TClass : class
        {
            ThreadContext.Properties["caller"] = $"[{file}:{line}({member})]";
            return LogManager.GetLogger<TClass>();
        }
    }
