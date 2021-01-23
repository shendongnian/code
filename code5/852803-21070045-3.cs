    public static void InvokeIfRequired(this ISynchronizeInvoke control, MethodInvoker action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(action);
        }
        else
        {
            action();
        }
    }
    
    
    
