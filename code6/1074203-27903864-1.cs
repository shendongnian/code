    private static void StartSomething()
    {
      IObservable<object> items = BackgroundWork();
      items.ObserveOn(F).Subscribe(item => F.ls1.Items.Add(item), ex => HandleException(ex));
    }
