    public class MyProjectionExpressions
    {
        public static Expression<Func<Log, dynamic>> LogSelector()
        {
            return log => new
            {
                logId = log.LogId,
                message = log.Message,
            };
        }
        private static Lazy<Func<Log, dynamic>> func;
        static MyProjectionExpressions()
        {
            func = new Lazy<Func<Log, dynamic>>(() => LogSelector().Compile());
        }
        public static dynamic LogSelector(Log log)
        {
            return func.Value(log);
        }
    }
