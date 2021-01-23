    void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        // don't bother with it if we are not modified
        if (Keyboard.Modifiers == ModifierKeys.None) return;
        foreach (InputBinding inputBinding in this.InputBindings)
        {
            KeyGesture keyGesture = inputBinding.Gesture as KeyGesture;
            if (keyGesture != null && keyGesture.Key == e.Key && keyGesture.Modifiers == Keyboard.Modifiers)
            {
                if (inputBinding.Command != null)
                {
                    inputBinding.Command.Execute(0);
                    e.Handled = true;
                }
            }
        }
        foreach (CommandBinding cb in this.CommandBindings)
        {
            RoutedCommand command = cb.Command as RoutedCommand;
            if (command != null)
            {
                foreach (InputGesture inputGesture in command.InputGestures)
                {
                    KeyGesture keyGesture = inputGesture as KeyGesture;
                    if (keyGesture != null && keyGesture.Key == e.Key && keyGesture.Modifiers == Keyboard.Modifiers)
                    {
                        command.Execute(0, this);
                        e.Handled = true;
                    }
                }
            }
        }
    }
