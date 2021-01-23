    // Please add the "async" keyword here, if possible
    private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      await LoadFromWebservice();
    }
    
    private async Task LoadFromWebservice()
    {
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri("http://mywebservice.com");
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
      using (var result = await client.GetStreamAsync("api/list/get"))
      {
        var serializer = new JsonSerializer(); // this is json.net serializer
        using (var streamReader = new StreamReader(result)) 
        {
          using (var jsonReader = new JsonTextReader(streamReader))
          {
            var theList = serializer.Deserialize<ListDTO>(jsonReader);
            
            LLS.ItemsSource = theList.Items.ToList();
          }
        }
      }
    }
