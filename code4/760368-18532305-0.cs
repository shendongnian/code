    class ThreadSafeLog
    {
        public ThreadSafeLog()
        {
            if (!File.Exists(Path_))
            {
                using (File.Create(Path_)) { }
            }
        }
    }
