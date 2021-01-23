    class Program
    {
      static BackgroundWorker _bw = new BackgroundWorker();
     
      static void Main()
      {
        _bw.DoWork += bw_DoWork;
        _bw.RunWorkerAsync ("Message to worker");
        Console.ReadLine();
      }
     
      static void bw_DoWork (object sender, DoWorkEventArgs e)
      {
        // This is called on the worker thread
        Console.WriteLine (e.Argument);        // writes "Message to worker"
        // Perform time-consuming task...
      }
    }
