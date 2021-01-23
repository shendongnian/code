    public partial class CustomerData : UserControl, INotifyPropertyChanged
    {
        private int curCustSeqNum;
        private Data.Customer customer;
        private IQueryable<Data.Customer> custQuery;
        public Data.Customer Customer
        {
            get { return customer; }
            set { this.customer = value; OnPropertyChanged("Customer"); }
        }
        public CustomerData()
        {
            InitializeComponent();
            // set the datacontext
            DataContext = this;
            ................
            Customer = custQuery.Skip(curCustSeqNum).Take(1).First();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
