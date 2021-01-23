        [System.Diagnostics.DebuggerStepThrough]
        public static void Log(Database db)
        {
            Action<string> Log = MyLogger.Log;
            db.Log = Log;
        }
