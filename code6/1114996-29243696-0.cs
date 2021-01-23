    private void DeleteCommandExecute(object sender, ExecutedRoutedEventArgs e)
    {
    }
    private void DeleteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }
    public MainWindow()
    {
        InitializeComponent();
        CommandBinding deleteCommandBinding = new CommandBinding(TestControl.DeleteCommand, DeleteCommandExecute, DeleteCommandCanExecute);
            this.CommandBindings.Add(deleteCommandBinding);
    }
