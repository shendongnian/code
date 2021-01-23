    namespace ExceptionHandlingTestConsole
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			try
    			{
    				Console.WriteLine("do something");
    				throw new Exception("my exception", new Exception("my inner exception"));
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex.Message);
    				if (ex.InnerException != null)
    				{
    					Console.WriteLine("inner exception msg: " + ex.InnerException.Message);
    				}
    			}
    			Console.ReadKey();
    		}
    
    	}
    }
