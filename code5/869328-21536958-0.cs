     public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            this.DataContext = vm;
            this.Loaded += (o,e) => vm.LoadData();
        }
        public class ViewModel : INotifyPropertyChanged
        {
            private IList<Charges> taxList;
            public ICollectionView TaxList { get; private set; }
            public void LoadData()
            {                
                taxList = Charges.GetChargeList("taxes");
                TaxList = CollectionViewSource.GetDefaultView(taxList);
                RaisePropertyChanged("TaxList");
                TaxList.CurrentChanged += TaxList_CurrentChanged;              
                var noTax = taxList.FirstOrDefault(c => c.ChargeName == "No Tax");
                TaxList.MoveCurrentTo(noTax);
            }
            void TaxList_CurrentChanged(object sender, EventArgs e)
            {
                var currentCharge = TaxList.CurrentItem as Charges;
                if(currentCharge != null)
                    MessageBox.Show(currentCharge.ChargeName);
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
