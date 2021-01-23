    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<GeneralMcmMessage> _generalMessages;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public ObservableCollection<GeneralMcmMessage> GeneralMcmMessages
        {
            get { return _generalMessages; }
            set
            {
                _generalMessages = value;
                OnPropertyChanged("GeneralMcmMessages");
            }
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            GeneralMcmMessages = new ObservableCollection<GeneralMcmMessage>();
            for (int i = 0; i < 10; i++)
            {
                var newMsg = new GeneralMcmMessage
                {
                    MessageId = i,
                    TimeStamp = DateTime.Now,
                };
                GeneralMcmMessages.Add(newMsg);
            }
        }
    }
