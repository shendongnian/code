    class Customer
    {
      public int ID {get; set;}
      public string Name {get; set;}
    }
    
    class MyViewModel: INotifyPropertyChanged
    {
      // Hook you repository (model) anyway you like (Singletons, Dependency Injection, etc)
      // For this sample I'm just crating a new one
      MyRepository repo = new MyRepository();
    
      public List<Customer> Customers 
      {
        get { return repo.Customers;}
      }
    
      public void ReadCustomers()
      {
        repo.ReadCustomers();
        InternalPropertyChanged("Customers");
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected void InternalPropertyChanged(string name)
      {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }
    
    class MyRepository
    {
      private List<Customer> customers;
      public List<Customer> Customers
      {
        get { return customers; }
      }
    
      public void ReadCustomers()
      {
        // db is the Entity Framework Context
        // In the real word I would use a separate DAL object
        customers = db.Customers.ToList();
      }
    }
