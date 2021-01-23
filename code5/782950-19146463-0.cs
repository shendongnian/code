    class myClass
    {
    static BackgroundWorker myBw = new BackgroundWorker();
    
    static void Main()
    {
    myBw .DoWork += myBw_DoWork;
    myBw .RunWorkerAsync ("an argument here");
    Console.ReadLine();
    }
    static void myBw_DoWork (object sender, DoWorkEventArgs e)
    {
    // This is called on the separate thread, argument is called as e.Argument
    // Perform heavy task...
    }
    }
