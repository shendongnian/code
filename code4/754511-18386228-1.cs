    namespace TimesheetManager.Helpers
    {
        public class SelectionChangedCommand
        {
            public static readonly DependencyProperty CommandProperty =
                DependencyProperty.RegisterAttached("Command", typeof(ICommand),
                typeof(SelectionChangedCommand), new PropertyMetadata(null, 
                OnCommandPropertyChanged));
            public static void SetCommand(DependencyObject d, ICommand value)
            {
                d.SetValue(CommandProperty, value);
            }
            public static ICommand GetCommand(DependencyObject d)
            {
                return (ICommand)d.GetValue(CommandProperty);
            }
            private static void OnCommandPropertyChanged(DependencyObject d,
                DependencyPropertyChangedEventArgs e)
            {
                var control = d as ListViewBase;
                if (control != null)
                    control.SelectionChanged += OnSelectionChanged;
            }
            private static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var control = sender as ListViewBase;
                var command = GetCommand(control);
                if (command != null && command.CanExecute(e))
                    command.Execute(e);
            }
        }
    }
