    public static void InvokeThreadSafeMethod(
        this System.Windows.FrameworkElement control,
        Action method)
    {
        if (control.Dispatcher.CheckAccess())
            method();
        else
            control.Dispatcher.Invoke(method);
    }
