    void Main()
    {
    	Person p = new Person() { Name = "Person Name", Dates = new List<System.DateTime>() { DateTime.Now } };
    
    	new Manager()
    	{
    		Subordinates = 5
    	}.Apply(p).Dump();
    }
    
    public static class Ext
    {
    	public static TResult Apply<TResult, TSource>(this TResult result, TSource source) where TResult: TSource
    	{
    		var props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    		foreach (var p in props)
    		{
    			p.SetValue(result, p.GetValue(source));
    		}
    		
    		return result;
    	}
    }
    
    class Person 
    {
    	public string Name { get; set; }
    	public List<DateTime> Dates { get; set; }
    }
    
    class Manager : Person
    {
    	public int Subordinates { get; set; }
    }
