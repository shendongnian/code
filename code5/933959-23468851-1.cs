    string resultJson = String.Empty;
	using (StreamReader r = new StreamReader("C:/Files/generated.json"))
	{
		string json = r.ReadToEnd();
		var result = JsonConvert.DeserializeObject<List<Form>>(json);
		foreach (var item in result)
		{ 
			if (item.id == FormtoSave.id)
			{
				item.Title = FormtoSave.Title;
				item.body = FormtoSave.body;
			}
		}
		resultJson = JsonConvert.SerializeObject(result);
	}
	File.WriteAllText("C:/Files/generated.json", resultJson);
