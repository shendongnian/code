	public class MyMarkerAttribute : Attribute 
	{
		
	}
	
	public class SomeClass 
	{
		// unmarked
		public List<Object> PropertyOne { get; set; }
		
		[MyMarkerAttribute] // marked
		public List<Object> PropertyTwo { get; set; }
	}
	foreach (PropertyInfo prop in props)
	{
		if (prop.GetCustomAttribute<MyMarkerAttribute>() != null)
		{
			// ...
		}
	}
