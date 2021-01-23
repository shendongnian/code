	byte[] DoSomething(params KeyValuePair<string, string>[] parameters)
	{
		var builder = new StringBuilder();
		for (int i = 0; i < parameters.Length; i++)
		{
			builder.AppendFormat("{0}={1}", parameters[i].Key, parameters[i].Value);
			if (i != parameters.Length - 1)
			{
				builder.Append("&");
			}
		}
		string urlParams = builder.ToString(); // contains "param1=value1&param2=value2"
		...
	}
