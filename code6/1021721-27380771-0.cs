    public class SimpleHandlerStartegy : ITransientErrorDetectionStrategy
    	{
    		public bool IsTransient(Exception ex)
    		{
    			if (ex is WebException)
    			{
    				return true;
    			}
    
    			return false;
    		}
    	}
