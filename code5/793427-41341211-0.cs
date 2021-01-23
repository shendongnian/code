    public UserControl()
        {
            InitializeComponent();
            Dispatcher.BeginInvoke(new System.Action(() => { Keyboard.Focus(TextBox); }),
                                   System.Windows.Threading.DispatcherPriority.Loaded);
        }
