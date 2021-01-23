    static class Extensions
    {
        public static void CrashOnException(this Task task)
        {
            task.ContinueWith((t) =>
            {
                Console.WriteLine(t.Exception.InnerException);
                Debugger.Break();
                Console.WriteLine("The process encountered an unhandled Exception during Task execution.  See above trace for details.");
                Environment.Exit(-1);
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
