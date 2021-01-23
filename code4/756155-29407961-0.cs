    static void WaitForRenderPass()
    {
      Application.Current.Dispatcher
        .BeginInvoke( DispatcherPriority.ApplicationIdle, new Action( () => {} ) )
        .Wait();
    }
