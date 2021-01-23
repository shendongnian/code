	var desDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
	var newDict = new Dictionary<string, object>(); //as you can't modify collection in foreach loop and the original dictionary can be out of scope of deserialization code
    
	foreach (var key in desDict.Keys)
	{ 
		switch(key)
		{
			case "int":
				newDict[key] = ((JObject)desDict[key]).ToObject<GenericItem<int>>();
				break;
			case "string":
				newDict[key] = ((JObject)desDict[key]).ToObject<GenericItem<string>>();
				break;
		}
	}
	desDict = newDict;
