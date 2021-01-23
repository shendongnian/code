	var jsonString = @"{ ""name"":""test"", ""array"": [""10"",""20"",""30"",""40""] }";
	dynamic dynamicObject = JsonConvert.DeserializeObject(jsonString);
	((string)dynamicObject.name).Dump();
	var items = dynamicObject.array.ToObject<List<Int32>>();
	foreach (var item in items)
	{
		Console.WriteLine(item);
	}
