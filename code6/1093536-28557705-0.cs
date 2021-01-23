    void bgrw_DoWork(object sender, DoWorkEventArgs e)
    {
        Console.WriteLine(DateTime.Now);
        this.BeginInvoke(new Action(() => { Thread.Sleep(2000); })); 
        Console.WriteLine(DateTime.Now);
    }  
