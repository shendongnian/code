    using(var context = new EntityContext())
    {
        Employee emp = new Employee()
        {
           LastName = lastName,
           Position = new Position { Name = name }
        };
    
        context.Employees.AddObject(emp);
        context.SaveChanges();
    }
