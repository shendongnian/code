    private void Target()
    {
        ...
    }
    Application.Current.Dispatcher.Invoke(
        DispatcherPriority.Background, new MyOwnAction(Target));
