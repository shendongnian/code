    // Please add the "async" keyword here, if possible
    private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      await LoadFromWebservice();
    }
    
    private async Task LoadFromWebservice()
    {
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri("http://mywebservice.com");
      client.DefaultRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
      using (var result = await client.GetStreamAsync("list/get"))
      {
        var serializer = new JsonSerializer(); // this is json.net serializer
        using (var streamReader = new StreamReader(result)) 
        {
          using (var jsonReader = new JsonTextReader(streamReader))
          {
            var theList = serializer.Deserialize<MyObject>(jsonReader);
            
            foreach (var item in theList.Items)
            {
              // Create a new Item which can be inserted into your list
              // and use "item" is its caption
              LLS.Items.Add(new ListItem(item));
            }
          }
        }
      }
    }
