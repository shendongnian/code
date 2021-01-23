    class Program
    {
      static BackgroundWorker _bw = new BackgroundWorker();
    
      static void Main()
      {
        _bw.DoWork += bw_DoWork;
        _bw.RunWorkerAsync ();
        Console.ReadLine();
      }
    
      static void bw_DoWork (object sender, DoWorkEventArgs e)
      {
        myObject1.myFunction(10, "Test");
        myObject2.myFunction(20, "Test");
        myObject3.myFunction(30, "Test");
      }
    }
