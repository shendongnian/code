    string path = "C:/Files/generated.json";
	var result = JsonConvert.DeserializeObject<List<Form>>(File.ReadAllText(path));
	foreach (var item in result)
	{ 
		if (item.id == FormtoSave.id)
		{
			item.Title = FormtoSave.Title;
			item.body = FormtoSave.body;
		}
	}
	File.WriteAllText(path, JsonConvert.SerializeObject(result));
