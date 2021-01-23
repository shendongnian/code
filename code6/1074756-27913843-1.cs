    public static class ExtensionMethods
    {
        public static void Restart(this Stopwatch watch)
        {
            watch.Stop();
            watch.Start();
        }
    }
