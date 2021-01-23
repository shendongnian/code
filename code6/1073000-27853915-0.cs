    class LogClickEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public DateTime DateTime { get; private set; }
        public LogClickEventArgs(string name)
        {
            Name = name;
            DateTime = DateTime.UtcNow;
        }
    }
    class ClickLogger
    {
        public static event EventHandler<LogClickEventArgs> LogClick;
        public static void SubscribeClick(Control control, EventHandler handler)
        {
            control.Click += (_ClickHandler + handler);
        }
        private static void _ClickHandler(object sender, EventArgs e)
        {
            LogClick.Raise(null, new LogClickEventArgs(((Control)sender).Name));
        }
    }
    static class Extensions
    {
        public static void Raise<T>(this EventHandler<T> handler, object sender, T e) where T : EventArgs
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
