    HttpResponseMessage response = client.GetAsync("api/yourcustomobjects").Result;
    if (response.IsSuccessStatusCode)
    {
        var yourcustomobjects = response.Content.ReadAsAsync<IEnumerable<YourCustomObject>>().Result;
        foreach (var x in yourcustomobjects)
        {
            //Call your store method and pass in your own object
            SaveCustomObjectToDB(x);
        }
    }
    else
    {
        //Something has gone wrong, handle it here
    }
