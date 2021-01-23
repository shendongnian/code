    static class Logger
    {
        [Conditional("DEBUG")]
        public static void Debug(Func<string> text)
        {
            Debug.Log(text());
        }
    }
