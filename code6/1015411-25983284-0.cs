	public class Test
	{
		[DefaultValue]
		public string Name { get; set; }
	}
			var instance = new Test();
			Type t = instance.GetType();
			// set up your fallback fucntion
			System.Reflection.PropertyInfo fallbackInfo = t.GetProperty("Name");
			//if else on the property lookup
			System.Reflection.PropertyInfo propInfo = t.GetProperty("Id") ?? fallbackInfo;
			// your code here
			Console.WriteLine(propInfo.ToString());
