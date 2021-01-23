    public void Foo()
    {
      var mre = new ManualResetEvent(false);
        mre.WaitOne(1000);
      Console.WriteLine("Foo");
    }
