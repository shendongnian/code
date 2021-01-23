	// TODO: error handling
	// Test classes
	public class A
	{
		public string Name { get; set; }
		public int Count;
	}
	public class B
	{
		public string Name { get; set; }
		public int Count;
	}
	// copy routine
	public B CopyAToB(A a)
	{
		B b = new B();
		// copy fields
		var typeOfA = a.GetType();
		var typeOfB = b.GetType();
		foreach (var fieldOfA in typeOfA.GetFields())
		{
			var fieldOfB = typeOfB.GetField(fieldOfA.Name);
			fieldOfB.SetValue(b, fieldOfA.GetValue(a));
		}
		// copy properties
		foreach (var propertyOfA in typeOfA.GetProperties())
		{
			var propertyOfB = typeOfB.GetProperty(propertyOfA.Name);
			propertyOfB.SetValue(b, propertyOfA.GetValue(a));
		}
		
		return b;
	}
	
