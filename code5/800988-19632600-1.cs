    private ObservableCollection<SalesPeriodV> salesPeriods = new ObservableCollection<SalesPeriodV>();
    public ObservableCollection<SalesPeriodV> SalesPeriods
    {
        get { return salesPeriods; }
        set { salesPeriods = value; NotifyPropertyChanged("SalesPeriods"); }
    }
    private SalesPeriodV selectedItem = new SalesPeriodV();
    public SalesPeriodV SelectedItem
    {
        get { return selectedItem; }
        set { selectedItem = value; NotifyPropertyChanged("SelectedItem"); }
    }
