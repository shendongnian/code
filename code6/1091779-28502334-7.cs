    void Foo()
    {
        Customer cust = null;
        var task = Task.Run(() => 
        {
           using (DataContext context = new DataContext())
           {
              cust = context.Customers.Single(c => c.Id == 1);
           }
        });
        
        task.ContinueWith(antecedent =>
        {
            // ...continue code in UI thread...
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
