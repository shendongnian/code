    private ObservableCollection<vw_ClientesFull> myClients;
    public ObservableCollection<vw_ClientesFull> MyClients 
    { 
        get { return myClients; }
        set
        {
           myClients = value;
           OnPropertyChanged("MyClients"); 
    }
