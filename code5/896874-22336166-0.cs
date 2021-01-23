    	void Main()
    	{
    		tName.test.DoIt(); // Fully qualify the static method name
    	}
    
    } // Close the generated context's class
    
    namespace tName
    {
    	public class test
    	{
    	// Define other methods and classes here
    		public static void DoIt()
    		{
    			Console.WriteLine("Done");
    		}
    	}
    // } Don't close the namespace. Let LinqPad do it.
