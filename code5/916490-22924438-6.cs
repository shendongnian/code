    public static RoutedCommand MyCustomCommand = new RoutedCommand();
    CommandBiding CustomCustomCommand = new CommandBinding(MyCystomCommand, CommandExecutedMethod, CommandCanExecuteMethod);
    this.CommandBindings.Add(CustomCommandBiding);
    KeyGesture MyKeyGesture = new KeyGesture(Key.G, ModifierKeys.Control);
    InputBinding CustomInputBinding = new InputBinding(MyCustomCommand, MyKeyGesture);
    this.InputBindings.Add(CustomInputBinding);
