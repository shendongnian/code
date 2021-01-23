    public static void SendToUIThread(Action method, bool UseExceptionHandling = true)
            {
                if (method == null)
                    throw new ArgumentNullException("method is missing");
    
                _threadSyncContext.Send(new SendOrPostCallback(delegate(object state)
                {
                    if (UseExceptionHandling)
                    {
                        try
                        {
                            method();
                        }
                        catch (Exception ex)
                        {
                            ErrorController.Instance.LogAndDisplayException(ex, true);
                        }
                    }
                    else
                        method();
    
                }), null);
            }
    
            public static void PostOnUIThread(this Control control, Action method, bool UseExceptionHandling = true)
            {
                if (method == null)
                    throw new ArgumentNullException("method is missing");
    
                if (control.InvokeRequired)
                    PostOnUIThread(method, UseExceptionHandling);
                else
                {
                    if (UseExceptionHandling)
                    {
                        try { method(); }
                        catch (Exception ex) { ErrorController.Instance.LogAndDisplayException(ex, true); }
                    }
                    else
                        method();
                }
            }
