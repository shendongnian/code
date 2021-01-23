    public static class ControlExtensions
    {
        public static void SafeInvoke(this Control control, Action action) 
        {
            if(control.InvokeRequired) 
            {
                control.BeginInvoke(action);
            }
            else 
            {
                action();
            }
        }
    }
