    JToken root = JToken.Parse(json);
	JToken nested = root["nested"];
	if (nested != null)
	{
		if (nested.Type == JTokenType.Null)
		{
			Console.WriteLine("nested is set to null");
		}
		else
		{
			Console.WriteLine("nested has a value: " + nested.ToString());
		}
	}
	else
	{
		Console.WriteLine("nested does not exist");
	}
