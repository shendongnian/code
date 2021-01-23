    private TaskCompletionSource<object> waiter = new TaskCompletionSource<object>(); 
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("This happens before button 2");
        
        waiter.Task.ContinueWith(_ =>
        {
            MessageBox.Show("This should wait until button2 is clicked.");
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private void button2_Click(object sender, EventArgs e)
    {
        waiter.SetResult(null);
        waiter = new TaskCompletionSource<object>(); //Reset the TaskCompletionSource
    }
