    public static class ControlEx
    {
        public static void DoSafely(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() =>
                    {
                        action();
                        Application.DoEvents();
                    }));
            else
                action();
        }
    }
