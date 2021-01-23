    public partial class Prompt : UserControl
    {
        private bool _canExecute;
        private EventHandler _canExecuteChanged;
        /// <summary>
        /// DependencyProperty for the OKCommand property.
        /// </summary>
        public static readonly DependencyProperty OKCommandProperty = DependencyProperty.Register("OKCommand", typeof(ICommand), typeof(Prompt), new PropertyMetadata(OnOKCommandChanged));
        /// <summary>
        /// Gets or sets the command to invoke when the OKButton is pressed.
        /// </summary>
        public ICommand OKCommand
        {
            get { return (ICommand)GetValue(OKCommandProperty); }
            set { SetValue(OKCommandProperty, value); }
        }
        protected override bool IsEnabledCore
        {
            get { return base.IsEnabledCore && _canExecute; }
        }
        // Command dependency property change callback. 
        private static void OnOKCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
            _canExecuteChanged = handler;
            if (command != null)
                command.CanExecuteChanged += _canExecuteChanged;
        }
        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (OKCommand != null)
                _canExecute = OKCommand.CanExecute(null);
            CoerceValue(UIElement.IsEnabledProperty);
        }
    }
