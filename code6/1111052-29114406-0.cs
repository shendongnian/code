    public class Program 
    {
    	public static void Main() 
    	{
    		Extract(new { Name = "Yoza" });
            Extract(new [] { new { Name = "Yoza" }, new { Name = "Dhika" } });
    	}
    
    	private static void Extract(object param = null) 
    	{
    		if (param.GetType().IsArray) 
    		{
    			var array = param as Array;
    			foreach(var element in array) 
    			{
    				foreach(var item in element.GetType().GetProperties()) 
    				{
    					Console.WriteLine(string.Format("{0}: {1}", item.Name, item.GetValue(element)));
    				}
    			}
    		} 
    		else 
    		{
    			foreach(var item in param.GetType().GetProperties()) 
    			{
    				Console.WriteLine(string.Format("{0}: {1}", item.Name, item.GetValue(param)));
    				item.GetValue(param);
    			}
    		}
    	}
    }
