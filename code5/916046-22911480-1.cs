    public class MyClass<T> where T : IIdent
    {
    	List<T> items;
    	
    	public int SearchOf(T pattern)
    	{
    		for (int index = 0; index < items.Count; index++)
                if (pattern.Id == items[index].Id)
                    return index;
                return -1;
    	}
    }
