    void Main()
    {
    	List<Emp> employees= new List<Emp>();
    	employees.Add(new Emp{ EmpId = 1, Type = "User", Emails = new List<string>(){"one@test.com"} }); 
    	employees.Add(new Emp{ EmpId = 1, Type = "User", Emails = new List<string>(){"two@test.com"} }); 
    	employees.Add(new Emp{ EmpId = 2, Type = "Test",  Emails = new List<string>(){"three@test.com"}  });  
    	employees.Add(new Emp{ EmpId = 2, Type = "Test",  Emails = new List<string>(){"four@test.com"} }); 
    	employees.Add(new Emp{ EmpId = 3, Type = "Test",  Emails = new List<string>(){"five@test.com"}  }); 
    	employees.Add(new Emp{ EmpId = 3, Type = "Test",  Emails = new List<string>(){"six@test.com"} }); 
    	employees.Add(new Emp{ EmpId = 4, Type = "User", Emails = new List<string>(){"seven@test.com"} });  
    	
    		var groupedList = from emp in employees
    					group emp.Emails by new { emp.EmpId, emp.Type } into g
    					select new Emp {
    										EmpId = g.Key.EmpId,
    										Type = g.Key.Type,
    										Emails = g.SelectMany(x => x).ToList()
    									};
    	    foreach (var result in groupedList)
    		{  //I'm using LINQPad to output  	
    		result.EmpId.Dump();
    		result.Emails.ForEach(e => e.Dump());				
    		}
    
    }
    public class Emp
    {
         public int EmpId { get; set; }
         public string Type { get; set; }
         public List<string> Emails { get; set; }             
    }
