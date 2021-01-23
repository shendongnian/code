      public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Client _selectedClient = new Client();
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (_selectedClient == value) return;
                _selectedClient = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Client> _clientCollection = new ObservableCollection<Client>();
        public ObservableCollection<Client> ClientCollection
        {
            get { return _clientCollection; }
            set
            {
                if (_clientCollection == value) return;
                _clientCollection = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            ClientCollection = new ObservableCollection<Client>()
        {
            new Client()
            {
                Name = "James",Age = 34, Location = "Paris"
            },
             new Client()
            {
                Name = "Joe",Age = 34, Location = "Us"
            },
             new Client()
            {
                Name = "Ann",Age = 34, Location = "Canada"
            },
        };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Client
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
    }
