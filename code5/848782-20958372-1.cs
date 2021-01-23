    private TaskCompletionSource<object> waiter = new TaskCompletionSource<object>(); 
    private void button1_Click(object sender, EventArgs e)
    {
        Panel coverScreen = new Panel();
        coverScreen.BackColor = Color.Black;
        coverScreen.Dock = DockStyle.Fill;
        this.Controls.Add(coverScreen);
        
        waiter.Task.ContinueWith(_ =>
        {
            this.Controls.Remove(coverScreen);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private void button2_Click(object sender, EventArgs e)
    {
        waiter.SetResult(null);
        waiter = new TaskCompletionSource<object>(); //Reset the TaskCompletionSource
    }
