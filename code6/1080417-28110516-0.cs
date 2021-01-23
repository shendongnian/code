    namespace API
    {
        public enum LogLevel
        {
            All, Debug, Error, Fatal
        }
    
        internal static class LogLevelExtension
        {
            internal static internlogic.Log.Level GetLevel(this LogLevel level)
            {
                switch (level)
                {
                    case LogLevel.All:
                        return internlogic.Log.Level.All;
                    case LogLevel.Debug:
                        return internlogic.Log.Level.Debug;
                    case LogLevel.Error:
                        return internlogic.Log.Level.Error;
                    case LogLevel.Fatal:
                        return internlogic.Log.Level.Fatal;
                    default:
                        throw new Exception("This shoudn't happen! : )");
                }
            }
        }
    }
