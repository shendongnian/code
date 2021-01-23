    public static class Log4NetExtensionMethods
    {
        public static void Debug( this ILog log, Func<string> formattingCallback )
        {
            if( log.IsDebugEnabled )
            {
                log.Debug( formattingCallback() );
            }
        }
        // .. other methods as required...
    }
