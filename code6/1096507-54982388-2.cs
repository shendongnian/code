    public partial class ProfileWrapper : UserControl
    {
        public ProfileWrapper()
        {
            InitializeComponent();
            test = abc;           
            Command = new RelayCommand(() => test.bZoomIn());
        }
        public ManualControl test;
        public RelayCommand Zoom { get; set; } 
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Zoom",
                typeof(ICommand),
                typeof(ProfileWrapper));
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
    }
