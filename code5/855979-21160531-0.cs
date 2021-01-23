        var customer = new Customer { CustomerName = "test" };
        _context.Customers.Add(customer);
        var newContact = new Contact();   
        customer.Contacts = new ObservableCollection<Customer>();// it needs becorse your collection is null 
        
       
        customer.Contacts.Add(newContact);  //just add new child to collection of parent
        _context.Customers.Add(customer);
        _context.SaveChanges();
