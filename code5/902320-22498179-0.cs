    public class Employee
    {
       public string Name { get; set; }
       public string Address { get; set; }
       public string DOB { get; set; }
       public string Gender { get; set; }
    }
    var textLines = File.ReadAllLines("FileName.txt");
    var employees = new List<Employee>();
    Parallel.ForEach(textLines,
    	emp =>
    	employees.Add(new Employee()
    	{
    	   Name = emp.Substring(51),
    	   Address = emp.Substring(51, 150),
    	   DOB = emp.Substring(201, 15),
    	   Gender = emp.Substring(216, 5)
    	}));
