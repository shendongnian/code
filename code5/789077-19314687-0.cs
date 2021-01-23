    public static void ShowForm()
    {
        if (dlg != null)
            dlg.BeginInvoke(new MethodInvoker(delegate { dlg.Dispose(); }));
    
        ThreadPool.QueueUserWorkItem(delegate(object state)
        {
            Application.Run(_dlg = new Form1());
        });
    }
    
    public static void SetText(string text)
    {
        _dlg.BeginInvoke(new MethodInvoker(delegate { dlg.SetText(text); }));
    }
