    public partial class WinFilesTransmitted : Window
    {
        static FTViewModel w = new FTViewModel();
        public WinFilesTransmitted()
        {
            InitializeComponent();
            DataContext = w;
        }
    }
