    public class MyClass<T> where T : IIdent
    {
    	List<T> items;
    	
    	public SearchOf(T pattern)
    	{
    		for (int index = 0; index < items.Count; index++)
                if (pattern.Id == searched[index].Id)
                    return index;
                return -1;
    	}
    }
