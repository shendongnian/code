    public class CurrentConditionDisplay : IObserver<WeatherUpdate>, IDisplay
    {
        public CurrentConditionDisplay(ISubject<WeatherUpdate> weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);   
        }
      
        public void Update(WeatherUpdate update)
        {
            this.temperature = update.Temperature;
            this.humidity = update.Humidity;
            this.pressure = update.Pressure;
        }
    }
