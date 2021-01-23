    public class clsPurchaseBillEntryList
    {
        // ...
        public clsPurchaseBillEntryList()
        {
             DoSomethingCommand = new RelayCommand(DoSomething, () => IsSerialNoProduct);
        }
        
        private void DoSomething()
        {
        } 
        public RelayCommand DoSomethingCommand { get; private set; }
    }
