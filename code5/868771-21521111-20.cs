    void Button_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew<int>(() => 
        {
            return div(32, 0); 
        }).ContinueWith((t) =>
        {
            if (t.IsFaulted)
            {
                // faulted with exception
                Exception ex = t.Exception;
                while (ex is AggregateException && ex.InnerException != null)
                    ex = ex.InnerException;
                MessageBox.Show("Error: " + ex.Message);
            }
            else if (t.IsCanceled)
            {
                // this should not happen 
                // as you don't pass a CancellationToken into your task
                MessageBox.Show("Canclled.");
            }
            else
            {
                // completed successfully
                MessageBox.Show("Result: " + t.Result);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
