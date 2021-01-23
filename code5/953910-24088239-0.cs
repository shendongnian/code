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
        //Get the expression as a Func<Log, dynamic>, then apply it
        //to your log object.
        private static Func<Log, dynamic> impl = LogSelector().Compile();
    
        public static dynamic LogSelector(Log log)
        {
            return impl(log);
        }
     }
