	using (var client = new HttpClient())
	{
		client.BaseAddress = new Uri("http://<url>/webservice.php");
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		var jsonContent = JsonConvert.SerializeObject(new YourObject
		{
            // Pseudo code... Replace <...> with your values etc
			Operation = <YourOperation>,
			ElementType = <YourElementType>,
			Element = <YourElement>,
			// etc...
		});
		HttpResponseMessage response;
		using (HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
		{
			response = await client.PostAsync("youroperation/", httpContent);
		}
		
		// Do something with response if you want
	}
