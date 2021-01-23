    class Foo<T> 
    {
    	public T Item { get; set; }
    	public Foo(T t)
    	{
    		Item = t;
    	}
    }
    
    class Bar 
    {
    	public override string ToString()
    	{
    		return "Bar";
    	}
    }
    
    class Baz : Bar 
    {
    	public override string ToString()
    	{
    		return "Baz";
    	}
    }
    
    class BarHolder 
    {
    	public Bar BarItem { get; set; }
    	public BarHolder(Bar bar)
    	{
    		BarItem = bar;
    	}
    }
    
    void Main()
    {
    	var wrappedBar = new BarHolder(new Bar());
    	var wrappedBaz = new BarHolder(new Baz());
    	
    	var barList = new List<Foo<BarHolder>>();
    	barList.Add(new Foo<BarHolder>(wrappedBar));
    	barList.Add(new Foo<BarHolder>(wrappedBaz));
    	
    	foreach (var obj in barList)
    	{
    		Console.WriteLine(obj.Item.BarItem);
    	}
    }
