    public static void SafeInvoke(System.Windows.Forms.Control control, System.Action action)
    {
        if (control.InvokeRequired)
            control.Invoke(new System.Windows.Forms.MethodInvoker(() => { action(); }));
        else
            action();
    }
