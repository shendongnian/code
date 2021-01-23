    public static void InvokeControlAction<t>(t cont, Action<t> action) where t : Control
    {
        if (cont.InvokeRequired)
        { cont.Invoke(new Action<t, Action<t>>(InvokeControlAction), 
    				new object[] { cont, action }); }
        else
        { action(cont); }
    }
