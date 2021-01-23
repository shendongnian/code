    public class Person
    {
        public string FirstName { get; private set; }
        public int Age { get; private set; }
    
        public Person(string firstName, int age)
        {
            FirstName = firstName;
            Age = age;
        }
    }
    ...
    public static List<Person> GetEmployees()
    {
        List<Employee> source = GenerateEmployeeCollection();
        var queryResult = from employee in source
                          where employee.Age > 20
                          select new Person(employee.FirstName, employee.Age);
    
        return queryResult.ToList();
    }
