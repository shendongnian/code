    public event EventHandler MyLongRunningTaskEvent;
    private void StartMyLongRunningTask() {
        MyLongRunningTaskEvent += myLongRunningTaskIsDone;
        Thread _thread = new Thread(myLongRunningTask) { IsBackground = true };
        _thread.Start();
        label.Text = "Running...";
    }
    private void myLongRunningTaskIsDone(object sender, EventArgs arg)
    {
        label.Text = "Done!";
    }
    private void myLongRunningTask()
    {
        try 
        { 
            // Do my long task...
        } 
        finally
        {
            this.BeginInvoke(Foo, this, EventArgs.Empty);
        }
    }
