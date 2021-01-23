    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel()
            {
                Items = new ObservableCollection<Item>()
                {
                    new Item(){
                        Selection ="A"
                    }
                }
            };
        }
    }
    public class Item : ViewModelBase
    {
        private string _selection = null;
        public string Selection
        {
            get { return _selection; }
            set { _selection = value; OnPropertyChanged("Selection"); }
        }
    }
    public class ViewModel : ViewModelBase
    {
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }
        private ObservableCollection<string> _possibilities = new ObservableCollection<string>()
        {
            "A", "B", "C"
        };
        public ObservableCollection<string> Possibilities
        {
            get
            {
                return _possibilities;
            }
            set
            {
                _possibilities = value;
                OnPropertyChanged("Possibilites");
            }
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var propChanged = PropertyChanged;
            if (propChanged != null)
                propChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
