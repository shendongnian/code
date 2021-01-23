    public class Customer
    {
        public string CustomerName {get; set;}
        public string CustomerAddress {get; set;}
        public bool CustomerNameDiffers {get; set;}
        public bool CustomerAddressDiffers {get; set;}
    }
    public class MyViewModel
    {
        public ObservableCollection<Customer> Customers {get; set;}
        
        //etc..
    }
