    class Program
    {
    	private class MyDynamic: DynamicObject
    	{
    
    	}
    
    	static void Main(string[] args)
    	{
    		dynamic test1 = new { Name = "Tim" };
    		//although I used the dynamic keyword here, it is NOT dynamic. dynamics are only dynamics if they support dynamically adding properties
    		//uncommenting this line will cause an exception
    		//test.LastName = "Jones"
    		if (test1 is IDynamicMetaObjectProvider) { Console.WriteLine("test1"); }
    
    		dynamic test2 = new MyDynamic();
    		if (test2 is IDynamicMetaObjectProvider) { Console.WriteLine("test2"); }
    
    		dynamic test3 = new ExpandoObject();
    		if (test3 is IDynamicMetaObjectProvider) { Console.WriteLine("test3"); }
    		dynamic test4 = new List<string>();
    		if (test4 is IDynamicMetaObjectProvider) { Console.WriteLine("test4"); }
    	}
    }
