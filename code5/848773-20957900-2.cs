    ManualResetEventSlim mres1 = null;
    private void button1_Click(object sender, EventArgs e)
    {
       System.Threading.ThreadPool.QueueUserWorkItem( Wait , null );
    }
    private void Wait(object state)
    {
        mres1 = new ManualResetEventSlim(false);
        mres1.Wait();
        //rest of the code to execute....
    }
    private void button2_Click(object sender, EventArgs e)
    {
        mres1.Set();
    }
