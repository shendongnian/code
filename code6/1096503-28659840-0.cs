    public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(UserControl));
        public ICommand Command
        {
            get 
            { 
                return (ICommand)GetValue(CommandProperty); 
            }
            set 
            { 
                SetValue(CommandProperty, value); 
            }
        }
