    public static void TryExecute(this ICommand command, object parameter, IInputElement target)
    {
        if (command == null) return;
    
        var routed = command as RoutedCommand;
        if (routed != null)
        {
            if (routed.CanExecute(parameter, target))
                routed.Execute(parameter, target);
        }
        else if (command.CanExecute(parameter))
            command.Execute(parameter);
    }
