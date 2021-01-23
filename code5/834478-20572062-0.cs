    public Class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
           cCustomer = new Customer();
        }
        public static Customer cCustomer { get; set; }
