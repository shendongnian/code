    public class Test
    {
    	private static object syncObj = new object();
    
        public static void Main()
    	{
    		var items = Enumerable.Range(0, 100).ToArray();
    		Parallel.ForEach(items, (item, state) =>
    		{
    			Task2(Task1(item));
    		});
    	}
    	
    	static int Task1(int item)
    	{
    		Console.WriteLine("Task 1 : {0}", item);
    		Thread.Sleep(100);
    		return item;
    	}
    	
    	static int Task2(int item)
    	{
    		Console.WriteLine("Task 2 : {0}", item);
    		return item;
    	}
    }	
