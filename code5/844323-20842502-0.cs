    class Program
    {
       static Mutex _m;
       static bool IsMutexExisting(string token)
       {  
	    try  
	    {
	      // Try to open existing mutex.
	      Mutex.OpenExisting(token);
	    } 
	    catch
	    {
	      return true;
	     }
	     // More than one instance.
       return false;
       }
