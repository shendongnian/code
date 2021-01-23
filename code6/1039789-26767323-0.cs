    using (WebClient wc = new Webclient())
    {
        var json = wc.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=London&mode=json");
        dynamic jsonResult = JsonConvert.DeserializeObject<ExpandoObject>(json , new ExpandoObjectConverter());
        // using dynamic object 
        var lon = jsonResult.coord.lon;
    }
