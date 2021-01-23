    public partial class MVVMTabControlSample : Window
    {
        public MVVMTabControlSample()
        {
            InitializeComponent();
            DataContext = new MVVMTabControlViewModel();
        }
    }
