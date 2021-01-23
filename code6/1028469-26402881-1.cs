    void Main()
    {
    	List<Emp> employees= new List<Emp>();
    	employees.Add(new Emp{ EmpId = 1, Type = "User", Email = "one@test.com" }); 
    	employees.Add(new Emp{ EmpId = 1, Type = "User", Email = "two@test.com" }); 
    	employees.Add(new Emp{ EmpId = 2, Type = "Test", Email = "three@test.com" });  
    	employees.Add(new Emp{ EmpId = 2, Type = "Test", Email = "four@test.com" }); 
    	employees.Add(new Emp{ EmpId = 3, Type = "Test", Email = "five@test.com" }); 
    	employees.Add(new Emp{ EmpId = 3, Type = "Test", Email = "six@test.com" }); 
    	employees.Add(new Emp{ EmpId = 4, Type = "User", Email = "seven@test.com" });  
    	
    	var groupedList = from emp in employees
    				group emp.Email by new { emp.EmpId, emp.Type } into g
    				select new { Key = g.Key, Type = g.Key.Type, Emails = g.ToList() };
    	
    	foreach (var result in groupedList)
    	{
    		//I'm using LINQPad to output the results
    		result.Key.EmpId.Dump();
    		foreach(var email in result.Emails)
    		{
    		email.Dump();
    		}   
    	}
    
    }
    public class Emp
    {
         public int EmpId { get; set; }
         public string Type { get; set; }
         public string Email { get; set; }             
    }
