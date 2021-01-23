    public class ForecastItem
    {
      public string Date {get;set;}
      public string Description {get;set;}
    }
    
    .
    .
    .
    
    WeatherService.WeatherSoapClient weather = new WeatherService.WeatherSoapClient("WeatherSoap");
    WeatherService.ForecastReturn for = weather.GetCityForecastByZIP(Zip.Text);
    if (for.Success)
    {
        response.Text = for.ResponseText;
        city.Text = for.City;
        State.Text = for.State;
        WeatherStationCity.Text = for.WeatherStationCity;
        List<ForecastItem> forecastItems = new List<ForecastItem>();
        foreach (var item in for.ForecastResult)
        {
             forecastItems.Add(new ForcastItem() {
                 Date = item.Date.ToShortDateString(),
                 Description = item.Desciption
             });
        }
        forecast.DataSource = forecastItems;
        forecast.DataBind();
    }
    
