    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      LoadFromWebservice();
    }
    
    private async void LoadFromWebservice()
	{
		HttpClient client = new HttpClient();
		client.BaseAddress = new Uri("http://thewebservice.tld/");
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		await client.GetStreamAsync("api/list/get")
			.ContinueWith(result =>
		{
			var stream = result.Result;
			var serializer = new JsonSerializer(); // this is json.net serializer
			using (var streamReader = new StreamReader(stream))
			{
				using (var jsonReader = new JsonTextReader(streamReader))
				{
					var theList = serializer.Deserialize<ListDTO>(jsonReader);
					Dispatcher.BeginInvoke(() => LLS.ItemsSource = theList.Items.ToList());
				}
			}
		});
	}
