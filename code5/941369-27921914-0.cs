    public static void InvokeIfRequired(this DispatcherControl control, Action operation)
    {
      if (control.Dispatcher.CheckAccess())
      {
        operation();
      }
      else
      {
        control.Dispatcher.BeginInvoke(DispatcherPriority.Normal, operation);
      }
    }
