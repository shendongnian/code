    public CustomerDTO GetCustomer(int Id)
    {
       var customer = db.Customer.Find(id));
       return new CustomerDTO{ Name = customer.CustomerName, OtherProperty = "others" };
    }
