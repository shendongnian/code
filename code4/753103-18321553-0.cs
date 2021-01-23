    public class Account
    {
        public string name { get; set;} 
        public string address { get; set;} 
        public decimal balance { get; set;} 
    }
    Account acc = new Account () { name="Some Name", address="Some Address", balance=10.0 }
