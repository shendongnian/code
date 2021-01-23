	using (var client = new HttpClient())
	{
		List<Task<HttpResponseMessage>> taskList = new List<Task<HttpResponseMessage>>();
		List<MyData> replies = new List<MyData>();
		for (var i = 0; i < MAX_NUMBER_REQUESTS; ++i)
		{
			taskList.Add(client.GetAsync(externalUrl));
		}
		var responses = await Task.WhenAll(taskList);
		foreach (var m in responses)
		{
			using (var reader = new StreamReader(await m.Content.ReadAsStreamAsync()))
			{
				replies.Add(JsonConvert.DeserializeObject<MyData>(reader.ReadToEnd()));
			}
		}
		foreach (var reply in replies)
		{
			// TODO:		
		}
	}
