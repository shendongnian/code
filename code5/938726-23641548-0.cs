    private EntityRef<Customer> _Customer;
            [Association(Storage = "_Customer", ThisKey = "CustomerID", IsForeignKey = true)]
            public Customer Customer
            {
                get { return this._Customer.Entity; }
                set 
                {
                    NotifyPropertyChanging("Customer");
                    this._Customer.Entity = value;
                    if (value != null)
                        customerID = value.CustomerID;
                    NotifyPropertyChanged("Customer");
                }
            } 
      
