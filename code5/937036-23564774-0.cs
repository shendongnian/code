    public class CustomerViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        ...
        public void Save()
        {
            if (!_customer.IsValid)
                throw new InvalidOperationException(Strings.CustomerViewModel_Exception_CannotSave);
            if (this.IsNewCustomer)
                _customerRepository.AddCustomer(_customer);
            
            base.OnPropertyChanged("DisplayName");
        }
