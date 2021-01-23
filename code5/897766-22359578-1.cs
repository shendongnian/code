    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Implementation of the INPC
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
  
        public class URIPairing
        {
            public string URI  { get; set; }
            public string Name { get; set; }
            public URIPairing(string _Name, string _URI)
            {
                this.Name = _Name;
                this.URI  = _URI;
            }
        }
        private ObservableCollection<URIPairing> _uris;
        public ObservableCollection<URIPairing> URIs { get; set { _uris = value; OnPropertyChanged(); } }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            this.URIs = new System.Collections.ObjectModel.ObservableCollection<URIPairing>();
            this.URIs.Add(new URIPairing( "DEV"     , "Some URL" ));
            this.URIs.Add(new URIPairing( "SANDBOX" , "Some URL" ));
            this.URIs.Add(new URIPairing( "QA"      , "Some URI" ));
        }
    }
