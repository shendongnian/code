    abstract class Module
	{
	    public abstract Options Params { get; set; }
	}
    
    class MyModule : Module
	{
	    private Options myParams = new MyOptions();
		public override Options Params
		{
			get { return myParams; }
			set { myParams = value; }
		}
	}
----
    var MyMod = new MyModule();
	(MyMod.Params as MyOptions).Param1 = "new value";
	Module Mod = MyMod;
	if (Mod.Params as MyOptions != null)
	{
		Console.WriteLine("cast OK"); 
	}
