    public delegate void OnFinishDelegate(APlugin p, AMessageEventArgs e);
        public delegate void OnExceptionDelegate(APlugin p, AMessageEventArgs e);
        public abstract class APlugin
        {
            public  event OnFinishDelegate OnFinish;
            public event OnExceptionDelegate OnException;
            AMessageEventArgs e = new AMessageEventArgs();
            public void Operate()
            {
                try
                {
                    // implement plugin work
                    // we don't care how does the third party programmer write his Plugin program
                    DoWork();
                    // if DoWork() completed , it will raise an OnFinish event
                    // in my host application
                    e.Message = "Completed";
                    if (OnFinish != null)
                    {
                        OnFinish(this, e);
                    }
                }
                catch(Exception ex)
                {
                    // if DoWork() throw exception, it will raise an OnException event
                    // in my host application
                    e.Message = ex.Message;
                    if (OnException!=null)
    	            {
    		             OnException(this,e);
    	            }
                }            
            }
            // In here, the third party programmer will override this DoWork() method
            private abstract void DoWork();
        }
