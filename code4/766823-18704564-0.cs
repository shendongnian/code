    async private void Form1_Load(object sender, EventArgs e)
    {
        string s = await Task<string>.Factory.StartNew(LongRunningTask, 
                                                     TaskCreationOptions.LongRunning);
        this.Text = s;
    }
    string LongRunningTask()
    {
        Thread.Sleep(10000);
        return "------";
    }
