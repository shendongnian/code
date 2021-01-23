    public interface SelectCustomerViewModel : INotifyPropertyChanged {
        event EventHandler CustomerSelected;        
        public ObservableCollection<Customer> Customers { get; }
        public Customer Customer { get; set; }
        public Command CustomerSelectedCommand { get; }
    }
    public interface MainViewModel : INotifyPropertyChanged {
        public SelectCustomerViewModel ModalContent { get; }
        public Command SelectCustomerCommand { get; }
        public bool IsSelectingCustomer { get; }
    }
