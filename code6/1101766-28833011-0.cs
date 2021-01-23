    public static class ControlExtension
    {
        public static void Do<TControl>(this TControl control, Action<TControl> action)
        where TControl : Control
        {
            if (control.InvokeRequired)
                control.Invoke(action, control);
            else
                action(control);
        }
    }
