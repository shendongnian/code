    DataContext.SlowLoadingCollection = null; // No collection, so will display fallback
    this.OnLoaded += () =>
    {
       Task.Run(()=>
       {
          Task.Delay(10000); // 10 second delay to simulate loading
          DataContext.SlowLoadingCollection = new []{ "Hello", "World", "!"};
       }
    }
