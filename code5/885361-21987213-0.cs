    var employees = new List<Employee>() {
        new Employee("John", "Development", 45000),
        new Employee("Mark", "Development", 55000),
        new Employee("Roger", "HR", 25000),
        new Employee("Jeff", "HR", 35000),
        new Employee("James", "Testing", 25000)
    };
    foreach (var g in employees.GroupBy(x => x.Dept)) {
        Console.WriteLine(g.Key);
        foreach (var e in g.OrderByDescending(x => x.Salary)) {
            Console.WriteLine(" - {0} makes ${1}/year", e.Name, e.Salary);
        }
    }
