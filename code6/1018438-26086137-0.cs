    void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
         if (!string.IsNullOrEmpty(e.Result))
         {
                WeatherData weatherDt = JsonConvert.DeserializeObject<WeatherData>(e.Result);
         }
    }
