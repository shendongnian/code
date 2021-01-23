    [RequiresSTA]
    [Test]
    public Task TestSta()
    {
      AsyncContext.Run(async () =>
      {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId+" - "+Thread.CurrentThread.GetApartmentState());
        // *** await something here ***
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId+" - "+Thread.CurrentThread.GetApartmentState());
        new FrameworkElement();
      });
    }
