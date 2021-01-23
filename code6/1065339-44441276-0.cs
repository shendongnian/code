    void Main()
    {
    	var volumeLabels = 
    		DriveInfo
    		.GetDrives()
    		.SelectSafe(dr => dr.VolumeLabel);
    }
    
    // Define other methods and classes here
    
    public static class LinqExtensions
    {
    	public static IEnumerable<T2> SelectSafe<T,T2>(this IEnumerable<T> source, Func<T,T2> selector)
    	{
    		foreach (var item in source)
    		{
    			T2 value = default(T2);
    			try
    			{	        
    				value = selector(item);
    			}
    			catch
    			{
    				continue;
    			}
    			yield return value;
    		}
    	}
    }
