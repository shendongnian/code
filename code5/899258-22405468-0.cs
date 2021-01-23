    public static class MouseOverHelpers
    {
        public static readonly DependencyProperty MouseOverCommand =
            DependencyProperty.RegisterAttached("MouseOverCommand", typeof(ICommand), typeof(MouseOverHelpers),
                                                                    new PropertyMetadata(null, PropertyChangedCallback));
        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var ui = dependencyObject as UIElement;
            if (ui == null) return;
            if (args.OldValue != null)
            {
                ui.RemoveHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(MouseLeave));
                ui.RemoveHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(MouseEnter));
            }
            if (args.NewValue != null)
            {
                ui.AddHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(MouseLeave));
                ui.AddHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(MouseEnter));
            }
        }
        private static void ExecuteCommand(object sender, bool parameter)
        {
            var dp = sender as DependencyObject;
            if (dp == null) return;
            var command = dp.GetValue(MouseOverCommand) as ICommand;
            if (command == null) return;
            if (command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
        private static void MouseEnter(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(sender, true);
        }
        private static void MouseLeave(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(sender, false);
        }
        public static void SetMouseOverCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(MouseOverCommand, value);
        }
        public static ICommand GetMouseOverCommand(DependencyObject o)
        {
            return o.GetValue(MouseOverCommand) as ICommand;
        }
    }
