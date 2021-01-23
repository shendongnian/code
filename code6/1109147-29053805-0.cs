	public static void WriteTypeAndValue<T>(T value, string prefix = null)
	{
		prefix = string.IsNullOrEmpty(prefix) ? null : "\""+prefix+"\": ";
		
		Type type;
		try
		{
			type = value.GetType();
		}
		catch (NullReferenceException)
		{
			Console.WriteLine(string.Format("{0} {1}: null value", prefix, typeof(T).FullName));
			return;
		}
		Console.WriteLine(string.Format("{0} {1}: \"{2}\"", prefix, type.FullName, value));
	}
	
