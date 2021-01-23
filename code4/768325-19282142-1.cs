    static void Main()
    		{
    			DisplayMemory();
    			List<object> objList = new List<object>();
    			for (int i = 0; i < 15; i++)
    			{
    				Console.WriteLine("--- New object #{0} ---", i + 1);
    
    				object o = new object();
                                objList.Add(o);
    				DisplayMemory();
       			}
    
    			GC.Collect();
   
    
    			DisplayMemory();
    			Console.WriteLine("--- press any key to quit ---");
    
    			Console.ReadLine();
    		}
