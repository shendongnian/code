    public class TempClass {
        private static ILog Log;
        public static void LogSomething(string something) {
            if (Log == null)
                Log = LogManager.GetLog(typeof(TempClass));
            Log.Info(something);
        }
    }
