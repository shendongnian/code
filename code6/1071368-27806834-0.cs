    private void btnStart_Click(object sender, EventArgs e)
    {
        if (cts != null)
        {
            cts.Cancel();
        }           
        cts = new CancellationTokenSource();
        Task.Factory.StartNew(()=> SlowFunction(SomeString, cts.Token), cts.Token);                        
    }
    public void SlowFunction(string str, CancellationToken token)
    {
        //Your code
    }
