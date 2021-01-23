    class CustomerList : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Customer> customers = ...
        public bool HasChanges {
            get {
                return customers.Any(customer => customer.Changed);
            }
        }
        // Callers who change customers inside your list must call this method
        public void ChangeCustomer(Customer c) {
            // Do whatever you need to do, ...
            ...
            // then send out the notification to WPF
            OnPropertyChanged("HasChanges");
        }
        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
