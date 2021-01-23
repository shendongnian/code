    public static void SafeBeginInvoke(System.Windows.Forms.Control control, System.Action action)
    {
        if (control.InvokeRequired)
            control.BeginInvoke(new System.Windows.Forms.MethodInvoker(() => { action(); }));
        else
            action();
    }
