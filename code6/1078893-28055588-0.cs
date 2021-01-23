    void Main()
    {
    	var list = new List<Project>() { new Project() { Order = 1, Id = 147, Name = "Summary" }, new Project() { Order = -9, Id = 211, Name = "Software Functionality" } };
    	int value= list.OrderByDescending(a => a.Order).ThenBy(a => a.Name).ToList().First().Id;
    	Console.WriteLine (value);
    }
    
    public class Project 
    {
    	public int Order {get;set;}
    	public int Id {get;set;}
    	public string Name {get;set;}
    }
