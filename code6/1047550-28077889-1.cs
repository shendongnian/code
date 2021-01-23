    static void LoadRelatedData()
    {
        using (var session = mystore.OpenSession())
        {
            var employeeFromQuery = session.Query<Employee>().FirstOrDefault();
            var order = session.Include<Order>(o => o.Employee).Load("orders/819"); 
  
            // Access them directly, as they have been resolved
            var employeeRelatedToOrder = order.Employee; 
            var dynamicRelatedToOrder = (dynamic)order.Employee;
        }
    }
