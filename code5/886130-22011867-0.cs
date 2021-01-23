    class Program
    	{
    		public static void Main(string[] args)
    		{
    			Console.WriteLine("Hello World!");
    			
    			string[] data = new String[] {"john","john","mike","ann","ann","ann"};
    			
    			var results = data.GroupBy(x => x).Select(g => new {name = g.Key, count = g.Count()});
    			
    			foreach (var result in results)
    			{
    				Console.WriteLine("{0} occurred {1} times...", result.name, result.count);
    			}
    			
    			
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
    	}
