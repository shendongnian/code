    static void Invoke(this Control control, TimeSpan timeout, MethodInvoker callback)
    {
        if (!control.InvokeRequired) {
            callback();
            return;
        }
    
        using (ManualResetEvent mre = new ManualResetEvent(initialState: false)) {
            bool cancelled = false;
            MethodInvoker wrapped = () => {
                mre.Set();
                if (!cancelled) {
                    callback();
                }
            };
    
            control.BeginInvoke(callback);
            if (!mre.WaitOne(timeout)) {
                cancelled = true;
            }
        }
    }
