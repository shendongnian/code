    static void LoadRelatedData()
    {
        using (var session = mystore.OpenSession())
        {
            var employeeFromQuery = session.Query<Employee>().FirstOrDefault();  //works
            var order = session.Include<Order>(o => o.Employee).Load("orders/819"); //works
            var employeeRelatedToOrder = order.Employee; // //session.Load<Employee>(order.Employee); //EXCEPTION
            var dynamicRelatedToOrder = (dynamic)order.Employee; ////session.Load<dynamic(order.Employee); //works
        }
    }
