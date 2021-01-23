    public class Employee {
        public int EmployeeID {get;set;}
        public string Name {get;set;}
        public string Position {get;set;}
        public decimal HourlyPayRate {get;set;}
    }
    ...
    // uses the "dapper" tool to provide the Query<T> extension method;
    // freely available from NuGet: PM> Install-Package Dapper
    var employees = connection.Query<Employee>(@"
    SELECT employeeID, name, position, hourlyPayRate 
    FROM dbo.employee 
    WHERE name LIKE @pattern",
        new { pattern = "%" + textBox1.Text + "%" }).ToList();
    grid.DataSource = employees;
