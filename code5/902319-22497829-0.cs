    Employee[] employees = new Employee[2000];
    int index = 0;
    foreach (var line in File.ReadLines("data.txt")) 
    {
        var employee = new Employee();
        employee.Name = line.Substring(0,50);
        employee.Address = line.Substring(51,150);
        employee.BDate = line.Substring(201,15);
        employee.Gender = line.Substring(216,5);
        employees[index++] = employee;
    }
