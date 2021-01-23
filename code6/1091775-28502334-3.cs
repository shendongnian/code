    void Foo()
    {
        Customer cust = null;
        Task.Run(() => 
        {
           using (DataContext context = new DataContext())
           {
              cust = context.Customers.Single(c => c.Id == 1);
           }
        });
    }
