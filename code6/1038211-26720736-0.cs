    Messenger.Default.Register<MyType>
    (
        this,
        (action) => Application.Current.Resources.Dispatcher.RunAsync(
            CoreDispatcherPriority.Normal, () => ReceiveMessage(action))
    );
