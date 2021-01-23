    public string Name { get; set;} 
    public string Address {get; set;}
    public decimal Balance {get; set;}
    public Account (string name, string address="not supplied", decimal balance=0;)
    { 
        Name = name; 
        Address = address; 
        Balance = balance; 
    }
