    public class IsolatedStorageHelper
    {
        private static Mutex mut = new Mutex(false, "IsoStorageMutex");
        
    	public static async Task WriteToFile(string text)
        {
    		mut.WaitOne();
    		try
    		{
    			...
    		}
    		finally
    		{
    			mut.ReleaseMutex();
    		}
        }
    	
    	public static async Task<string> ReadFile()
        {
    		  mut.WaitOne();
    		  var result = String.Empty;
    		  try
    		  {
    			  ...
    		  }
    		  finally
    		  {
    			  mut.ReleaseMutex();
    		  }
    		  return result;
        }
    }
