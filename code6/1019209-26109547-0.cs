	public static string Transform(string json)
	{
		JObject root = JObject.Parse(json);
		
		JObject itemsObj = new JObject();
		foreach (JObject item in root["items"])
		{
			JToken id = item["id"];
			id.Parent.Remove();
			itemsObj.Add(id.ToString(), item);
		}
		root["items"].Parent.Remove();
		root.Add("items", itemsObj);
		return root.ToString();
	}
