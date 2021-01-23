    class ErrorEventArgs : EventArgs
    {
        public Exception Exception { get; set; }
    }
    event EventHandler<ErrorEventArgs> Error = delegate { };
    void Form_Load(object sender, EventArgs e)
    {
        this.Error += (sError, eError) =>
            // handle the error on the UI thread
            Debug.Print(eError.Exception.ToString()); 
        ThreadPool.QueueUserWorkItem(x =>
        {
            this.BeginInvoke(new MethodInvoker(() => 
            {
                try
                {
                    Test();
                }
                catch (Exception ex)
                {
                    // fire the Error event
                    this.Error(this, new ErrorEventArgs { Exception = ex });
                }
            }));
        });
    }
