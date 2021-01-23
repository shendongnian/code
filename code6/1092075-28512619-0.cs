    class script1
    {
        public static string StatusText { get; private set; }
        public static event EventHandler StatusTextChanged;
        static public void Run()
        {
            ChangeStatusText("Script1 is running");
            function.wait(5);
            ChangeStatusText("Script1 is done");
        }
        static void ChangeStatusText(string text)
        {
            StatusText = text;
            EventHandler handler = StatusTextChanged;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }
    }
