    public class MainWindowViewModel
    {
        private readonly string _customerCode;
        public MainWindowViewModel(string customerCode)
        {
            if (customerCode == null)
                throw new ArgumentNullException("customerCode");
            _customerCode = customerCode;
        }
        // Other code in this class can access the _customerCode field
        // to retrieve the value from the command line
    }
