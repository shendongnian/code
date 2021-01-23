    /// <summary>
    /// Generates the employees in a hierarchy way.
    /// </summary>
    /// <returns>Returns the root employee.</returns>
    Employee GenerateEmployees()
    {
        var doug = new Employee("Doug");
        doug.Employees.Add(new Employee("Allan", doug));
    
        var bob = new Employee("Bob", doug);
        doug.Employees.Add(bob);
    
        var smith = new Employee("Smith", bob);
        bob.Employees.Add(smith);
    
        smith.Employees.Add(new Employee("Joseph", smith));
        smith.Employees.Add(new Employee("Dave", smith));
    
        return doug;
    }
