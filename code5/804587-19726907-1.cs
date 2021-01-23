    public static class Logger
    {
        [Conditional("TRACE")]
        public static void Write(string text)
        {
           // some stuff
        }
    }
