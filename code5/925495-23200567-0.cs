    void Main()
    {
        MyMethod(new EmployeeComparer());
    }
    void MyMethod(IComparer<Employee> comparer)
    {
        var emp1 = new Employee { Name = "George" };
        var emp2 = new Employee { Name = "Tom" };
        Console.WriteLine(comparer.Compare(emp1, emp2));
    }
