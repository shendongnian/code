    Public SomeContextConstructor()
    {
        AddDebugLogging() // Call the debug method for the log
    }
    // Have this method in your context class
    [Conditional("DEBUG")]
        private void AddDebugLogging()
        {
            this.Database.Log = s => Debug.Write(string.Format("EF Log: {0}", s));
        }
