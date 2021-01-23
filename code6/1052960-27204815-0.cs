	dynamic d = JsonConvert.DeserializeObject(json);
	if (d.propertyA.GetType() == typeof (Newtonsoft.Json.Linq.JObject))
	{
		Console.WriteLine(d.propertyA.first);
	}
	else if (d.propertyA.GetType() == typeof (Newtonsoft.Json.Linq.JArray))
	{
		if (d.propertyA.Count > 0)
		{
			Console.WriteLine(d.propertyA[0].first);
		}
	}
