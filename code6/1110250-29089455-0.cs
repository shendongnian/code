    private readonly System.Threading.EventWaitHandle waitHandle = new System.Threading.AutoResetEvent(false);
    private void btnOk_Click(object sender, EventArgs e)
    {
        // Do some work
        Task<string> task = Task.Run(() => GreatBigMethod());
        string GreatBigMethod = await task;
        // Wait until condition is false
        waitHandle.WaitOne();
        Console.WriteLine("Excel is busy");
        waitHandle.Reset();
        // Do work
        Console.WriteLine("YAY");
     }
