	public void OutputStringProperties(Type type)
	{
		foreach (PropertyInfo prop in type.GetProperties())
		{ 
			if(prop.PropertyType == typeof(string))
			{
				Console.WriteLine(prop.Name);              
			}
			else
			{
				OutputStringProperties(prop.PropertyType);
			}
		}
	}
