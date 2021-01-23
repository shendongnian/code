    void FireAndForgetTaskWithExceptionHandling(Action a)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    a.Invoke();
                }
                catch (Exception e)
                {
                    Handler(new Object(), new EventArgs());
                }
            }
        );
        }
