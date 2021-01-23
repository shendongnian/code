    [HttpGet]
    public IQueryable<Employee> Employees(double minWeight) {
      var emps = ContextProvider.Context.Employees.Include("Orders").ToList();
      // remove selected orders from what gets returned to the client.
      emps.ForEach(emp => {
        var ordersToRemove = emp.Orders.Where(o => o.Freight < minWeight).ToList();
        ordersToRemove.ForEach(o => emp.Orders.Remove(o));
      });
      return emps;
    }
