    private static ICommand _command;
    private static void ClosedChanged(
        DependencyObject target,
        DependencyPropertyChangedEventArgs e)
        {
            var window = target as Window;
            if (window != null)
            {
                _command = e.NewValue as ICommand;
                window.Closed += (sender, args) =>
                {
                    if (_command != null)
                        _command.Execute(null);
                }
            }
        }
