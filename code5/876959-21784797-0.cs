      /* Set the new handler. */
      Application.Current.Resuming += (s, e) =>
      {
        /* Start a task to wait for UI. */
        Task.Factory.StartNew(() =>
        {
          Windows.Foundation.IAsyncAction ThreadPoolWorkItem = Windows.System.Threading.ThreadPool.RunAsync(
          (source) =>
          {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
             () =>
             {
               /* Do something on UI thread. */
             });
          });
        });
      };
