    private void CanExecuteChanged(object sender, EventArgs e)
    {
        if (Command != null)
        {
            RoutedCommand command = Command as RoutedCommand;
            // If a RoutedCommand. 
            if (command != null)
            {
                _canExecute = command.CanExecute(CommandParameter, CommandTarget);
            }
            // If a not RoutedCommand. 
            else
            {
                _canExecute = Command.CanExecute(CommandParameter);
            }
        }
        CoerceValue(UIElement.IsEnabledProperty);
    }
