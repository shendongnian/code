    var employees = new List<Employee>() {
        new Employee("John", "Development", 45000),
        new Employee("Mark", "Development", 55000),
        new Employee("Roger", "HR", 25000),
        new Employee("Jeff", "HR", 35000),
        new Employee("James", "Testing", 25000)
    };
    var grouped = employees.GroupBy(x => x.Dept)
                           .ToDictionary(
                               key => key.Key, 
                               value => new List<Employee>(value.OrderByDescending(x => x.Salary))
                           );
    foreach (var g in grouped) {
        Console.WriteLine(g.Key);
        foreach (var e in g.Value) {
            Console.WriteLine(" - {0} makes ${1}/year", e.Name, e.Salary);
        }
    }
