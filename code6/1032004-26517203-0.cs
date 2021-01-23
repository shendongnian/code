    try
    {
        Employee EmPy1 = new Employee("111-11-111", -4.0);
    }
    catch (EmployeeException ex)
    {
        Console.WriteLine(ex.Message);
    }
    try
    {
        Employee EmPy2 = new Employee("222-22-222", 7.5);
    }
    catch (EmployeeException ex)
    {
        Console.WriteLine(ex.Message);
    }
    ...
