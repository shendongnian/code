    private readonly Statistics _statistics;
    public ICommand ClickCommand { get; set; }
    private ReservationDataViewModel(Statistics statistics)
    {
        _statistics = statistics;
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
        // e.g. say there is a property on your statistics called 'ReservationCount'
        // the command adds a reservation (increments the count)
        _statistics.ReservationCount += 1;
    }
    private void ClickCommandCanExecute(object sender, CanExecuteRoutedEventArgs args)
    {
        args.CanExecute = true; // put your can execute logic here...
    }
