    public class CategoryHelper
    {
    	Dictionary<int,string> cachedDesc; //Dictionary used to store the descriptions
    	public static string GetCategoryDesc(int CatgeoryId)
    	{
    		if (cachedDesc==null) cachedDesc = new Dictionary<int,string>(); // Instatiate the dictionary the first time only
    		if(cachedDesc.ContainsKey(CatgeoryId)) //We check to see if we have cached this value before
    		{
    			return cachedDesc[CatgeoryId];
    		}
    		else
    		{
    			var description = .... get value from DB
    			cachedDesc.add(CatgeoryId, description); //Store the value for later use
    			return description;
    		}
    	}
    }
