    class ClickLogger
    {
        public static event EventHandler<LogClickEventArgs> LogClick;
        public static void AttachLogging<T>(ControlCollection controls) where T : Control
        {
            foreach (Control control in controls)
            {
                if (control is T)
                {
                    _AttachLoggingToControl(control);
                }
                AttachLogging<T>(control.Controls);
            }
        }
        private static void _AttachLoggingToControl(Control control)
        {
            FieldInfo fi = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            PropertyInfo pi = typeof(Control).GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
            object eventClickObject = fi.GetValue(null);
            EventHandlerList handlerList = (EventHandlerList)pi.GetValue(control);
            EventHandler clickHandlers = (EventHandler)handlerList[eventClickObject];
            handlerList[eventClickObject] = _ClickHandler + clickHandlers;
        }
        private static void _ClickHandler(object sender, EventArgs e)
        {
            LogClick.Raise(null, new LogClickEventArgs(((Control)sender).Name));
        }
    }
