    public partial class Prompt : UserControl
    {
        private EventHandler canExecuteChangedHandler;
        /// <summary>
        /// DependencyProperty for the OKCommand property.
        /// </summary>
        public static readonly DependencyProperty OKCommandProperty = DependencyProperty.Register("OKCommand", typeof(ICommand), typeof(Prompt), new PropertyMetadata(OnCommandChanged));
        /// <summary>
        /// Gets or sets the command to invoke when the OKButton is pressed.
        /// </summary>
        public ICommand OKCommand
        {
            get { return (ICommand)GetValue(OKCommandProperty); }
            set { SetValue(OKCommandProperty, value); }
        }
        // Command dependency property change callback. 
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Prompt p = (Prompt)d;
            p.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }
        public Prompt()
        {
            InitializeComponent();
        }
        // Add a new command to the Command Property. 
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            // If oldCommand is not null, then we need to remove the handlers. 
            if (oldCommand != null)
                RemoveCommand(oldCommand);
            
            AddCommand(newCommand);
        }
        // Remove an old command from the Command Property. 
        private void RemoveCommand(ICommand command)
        {
            EventHandler handler = CanExecuteChanged;
            command.CanExecuteChanged -= handler;
        }
        // Add the command. 
        private void AddCommand(ICommand command)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            canExecuteChangedHandler = handler;
            if (command != null)
                command.CanExecuteChanged += canExecuteChangedHandler;
        }
        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
            {
                RoutedCommand command = Command as RoutedCommand;
                // If a RoutedCommand. 
                if (command != null)
                {
                    if (command.CanExecute(CommandParameter, CommandTarget))
                        this.IsEnabled = true;
                    else
                        this.IsEnabled = false;
                }
                // If a not RoutedCommand. 
                else
                {
                    if (Command.CanExecute(CommandParameter))
                        this.IsEnabled = true;
                    else
                        this.IsEnabled = false;
                }
            }
        }
    }
