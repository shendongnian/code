	private static async Task RunAsync()
	{
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri("http://www.omdbapi.com");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage response = await client.GetAsync("?t=Captain+Phillips&r=json");
			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Success");
			}
			else
			{
				Console.WriteLine("Error with feed");
			}
		}
	}
