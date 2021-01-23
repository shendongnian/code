    public ICommand ClickCommand { get; set; }
    private ViewModel()
    {
        InitialiseCommands();
    }
    private void InitialiseCommands()
    {
        ClickCommand = new RoutedUICommand("ClickCommand", "ClickCommand", typeof(ViewModel));
        CommandBinding clickCommandBinding = new CommandBinding(ClickCommand, ExecuteClickCommand, ClickCommandCanExecute);
        CommandManager.RegisterClassCommandBinding(typeof(ViewModel), clickCommandBinding);
    }
    private void ExecuteClickCommand(object sender, ExecutedRoutedEventArgs args)
    {
        // perform click logic here...
    }
    private void ClickCommandCanExecute(object sender, CanExecuteRoutedEventArgs args)
    {
        args.CanExecute = true; // put your can execute logic here...
    }
