    public static void DoEvents()
    {
      if (Application.Current == null)
        return;
      Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Delegate) (() => {}));
    }
