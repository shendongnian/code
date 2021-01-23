    public class Program
    {
    	public static void Main()
    	{
    		var l1= new List<int>{1,2,3};
            var l2= new List<int>{4,5,6};
            var l3= new List<int>{7,8,9};
            var testList = new List<Test>{new Test{Id=9,Name="test1"},new Test{Id=11,Name="test1"},new Test{Id=5,Name="test1"},new Test{Id=7,Name="test1"},new Test{Id=2,Name="test1"}};
            var orderedList= testList.OrderByDescending(e=> l1.Contains(e.Id)).ThenByDescending(e=> l2.Contains(e.Id)).ThenByDescending(e=> l3.Contains(e.Id));
            Console.WriteLine(string.Join("\t", orderedList.Select(e=> e.Id).Cast<int>().ToArray()));
    // it prompts 2    5    9    7    11
    	}
    }
    
    public class Test{
    	public int Id{get; set;}
    	public string Name{get; set;}
    }
