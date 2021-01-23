    private ObservableCollection<Invoice> _ocOpenInvoices;
    public ObservableCollection<Invoice> ocOpenInvoices
    { 
      get { return _ocOpenInvoices ; } 
      set { _ocOpenInvoices = value; OnPropertyChange("ocOpenInvoices"); }
    }
