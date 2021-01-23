      var myList = new List<string>();
      if(!myList.HasValue())
      {
    	 Console.WriteLine("List has value(s)");			  
      }
      
      if(!myList.HasValue())
      {
    	 Console.WriteLine("List is either null or empty");			  
      }
      
      if(myList.HasValue())
      {
    	  if (!myList[0].HasValue()) 
    	  {
    		  myList.Add("new item"); 
    	  }
      }
          	  
    	      	  
    
    
    /// <summary>
    /// This Method will return True if List is Not Null and it's items count>0       
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns>Bool</returns>
    public static bool HasValue<T>(this IEnumerable<T> items)
    {
    	if (items != null)
    	{
    		if (items.Count() > 0)
    		{
    			return true;
    		}
    	}
    	return false;
    }
    
    		
    /// <summary>
    /// This Method will return True if List is Not Null and it's items count>0       
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static bool HasValue<T>(this List<T> items)
    {
    	if (items != null)
    	{
    		if (items.Count() > 0)
    		{
    			return true;
    		}
    	}
    	return false;
    }
    
    
    /// <summary>
    ///  This method returns true if string not null and not empty  
    /// </summary>
    /// <param name="ObjectValue"></param>
    /// <returns>bool</returns>
    public static bool HasValue(this string ObjectValue)
    {
    	if (ObjectValue != null)
    	{
    		if ((!string.IsNullOrEmpty(ObjectValue)) && (!string.IsNullOrWhiteSpace(ObjectValue)))
    		{
    			return true;
    		}
    	}
    	return false;
    }
              
