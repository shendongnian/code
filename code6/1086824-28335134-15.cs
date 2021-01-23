	class Program
	{
		static void Main(string[] args)
		{
			var type = Type.GetTypeFromProgID(MyComLibConstants.FactoryProgId);
			var factory = Activator.CreateInstance(type) as IFactory;
			var manager = factory.CreateManager();
			var x = manager.Array[500].Whasit;
		}
	}
