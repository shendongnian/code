    List<CustomerData> GetData()
    {
      var data = from cus in context.Customer 
                 select new CustomerData{
                     CustomerID = cus.CustomerID,
                     Name = cus.Name,
                     Salary = cus.Salary
                     IsProcessed = Your custom field data
                 };
      return data.ToList();
    }
