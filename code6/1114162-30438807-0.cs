    public static RoutedCommand CustomCommand = new RoutedCommand();
            CommandBinding CustomCommandBinding = new CommandBinding(CustomCommand, ExecutedCustomCommand, CanExecuteCustomCommand);
            this.CommandBindings.Add(CustomCommandBinding);
            customControl.Command = CustomCommand;
            KeyGesture kg = new KeyGesture(Key.F, ModifierKeys.Control);
            InputBinding ib = new InputBinding(CustomCommand, kg);
            this.InputBindings.Add(ib);
        private void ExecutedCustomCommand(object sender, ExecutedRoutedEventArgs e)
        {
            //what to do;
            MessageBox.Show("Custom Command Executed");
        }
        private void CanExecuteCustomCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;
            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
