    public class User
    {
        public ObservableCollection<Address> Addresses;
    
        public Address DefaultAddress
        {
            get
            {
                return Addresses.Single(a => a.IsDefault);
            }
            set
            {
                Addresses.Remove(DefaultAddress);
                Addresses.Insert(0, value);
            }
        }
    }
