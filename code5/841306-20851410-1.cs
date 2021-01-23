     button.Click += async delegate {
    
        var client = new HttpClient();
        var url = "http://iforindia.azurewebsites.net/api/state/uid/33F8A8D5-0DF2-47A0-9C79-002351A95F88";
        var response = await _client.GetAsync(url);
        if (response != null && response.ReasonPhrase.Contains("OK"))
        {
                var jsonSerializer = new DataContractJsonSerializer(typeof(state));
                var stream = await response.Content.ReadAsStreamAsync();
                var s = jsonSerializer.ReadObject(stream) as state;
    
                if (s != null)
                {
                     tv.Text = s.name+""+s.population;
                }   
            }
       };
