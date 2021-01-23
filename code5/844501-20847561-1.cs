    public class YourObject
    {
    	public string Id {get;set;}
    	public string Source {get;set;}
    }
    void Main()
    {
    	List<string> updateIds = new List<string>() {"1", "2"}; 
    	List<YourObject> oldList = new List<YourObject>() 
    	{
    		new YourObject { Id = "1", Source = "test1" },
    		new YourObject { Id = "2", Source = "test2" },
    		new YourObject { Id = "3", Source = "test3" },
    		new YourObject { Id = "4", Source = "test4" }
    	};
    	List<YourObject> newList = oldList.Where(i => updateIds.Contains(i.Id))
                                          .Select(j => {
                                                          j.Id="'MyValue.'" + j.Id; 
                                                          return j;
                                                       }).ToList();
    }
