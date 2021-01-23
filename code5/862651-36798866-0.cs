    public RoutedCommand myCommand = new RoutedCommand();
    public void Init() {
        myCommand.InputGestures.Add(new KeyGesture(Key.V, ModifierKeys.Control | ModifierKeys.Shift);
        var bind = new CommandBinding { Command = myCommand };
        bind.Executed += new ExecutedRoutedEventHandler((sender,e) => {
            // do stuff here.
        });
        CommandBindings.Add(bind);
    }
