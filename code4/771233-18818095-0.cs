    Messenger.Default.Register<NavigateMessage>(this, (navigateMessage) =>
    {
      Deployment.Current.Dispatcher.BeginInvoke(() =>
      {
        ApplicationParameter = navigateMessage.Parameter;
        RootFrame.Navigate(navigateMessage.Destination);
      });
    });
