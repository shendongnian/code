    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<MyProduct> priceList;
        public MainWindow()
        {
            InitializeComponent();
            Pricelist = new ObservableCollection<MyProduct>();
            this.DataContext = this;
        }
        public ObservableCollection<MyProduct> Pricelist
        {
            get
            {
                return this.priceList;
            }
            set
            {
                this.priceList = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PriceList"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class MyProduct : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                this.RaisePropertyChanged("Price");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected void RaisePropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Price":
                        {
                            decimal temdecimal = 0.00m;
                            if (Price != null && !decimal.TryParse(Price, out temdecimal))
                            {
                                result = "Price is invalid";
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return result;
            }
        }
    }
