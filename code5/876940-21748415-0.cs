        public static bool GetIsRegistered(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsRegisteredProperty);
        }
        public static void SetIsRegistered(DependencyObject obj, bool value)
        {
            obj.SetValue(IsRegisteredProperty, value);
        }
        // Using a DependencyProperty as the backing store for IsRegistered.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRegisteredProperty =
            DependencyProperty.RegisterAttached("IsRegistered", typeof(bool), typeof(SelectionChangeCommand), new PropertyMetadata(false, new PropertyChangedCallback(RegisterForCommand)));
        private static void RegisterForCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Selector)
            {
                Selector sel = (Selector)d;
                if ((bool)e.NewValue)
                {
                    sel.SelectionChanged += sel_SelectionChanged;
                }
                else
                {
                    sel.SelectionChanged -= sel_SelectionChanged;
                }
            }
        }
        static void sel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is Selector)
            {
                Selector sel = (Selector)sender;
                ICommand command = GetCommand(sel);
                if (command!=null && command.CanExecute(null))
                    command.Execute(sel);
            }
        }
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }
        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(SelectionChangeCommand), new PropertyMetadata(null));
    }
