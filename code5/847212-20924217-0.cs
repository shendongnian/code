    Task.Factory.StartNew(() =>
    {
      foreach (var item in itemsReady.GetConsumingEnumerable())
      {
        ...
      }
    }
