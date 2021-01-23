    //declare ipmac as public property
    public ObservableCollection<IPMAC> ipmac { get; set; } 
    
    //In constructor : initialize ipmac and set up DataContext
    ipmac = new ObservableCollection<IPMAC>();
    this.DataContext = this;
    
    //In XAML : bind ItemsSource to ipmac
    <DataGrid ItemSource="{Binding ipmac}" Name="dg" ... />
