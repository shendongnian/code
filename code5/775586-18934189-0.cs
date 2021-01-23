    static RoutedUICommand novo = new RoutedUICommand(
                                         "Novo", 
                                         "Novo", 
                                         typeof(HWCommand), 
                                         new InputGestureCollection(
                                             new InputGesture[] { new KeyGesture(Key.N, ModifierKeys.Control) }
                                         ));
