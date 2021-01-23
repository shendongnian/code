	public abstract class BaseClass
	{
		public abstract void DoSomething();
	}
	public class Apple : BaseClass
	{
		public int Diameter { get; set; }
		public override void DoSomething()
		{
			// Do something specific for Apple
		}
	}
	//...
	public void DoStuff(Query query)
    {
        // The query only ever returns bananas OR Apples. Never both.
        var items = repository.GetItems<BaseClass>(query);
        foreach (var item in items)
		{
			item.DoSomething();
		}
    }
