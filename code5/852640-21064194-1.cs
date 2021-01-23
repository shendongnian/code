    public class Weather
    {
        private readonly IWeatherDataProvider _weatherDataProvider;        
        private CompositeDisposable disposables = new CompositeDisposable();
        
        public Weather(IWeatherDataProvider weatherDataProvider)
        {
            InitializeComponent();
            _weatherDataProvider = weatherDataProvider;
                    
            Loaded += (sender, args) =>
            {
              var weather = Observable.Interval(TimeSpan.FromMinutes(15))
                  .SelectMany(_ => weatherDataProvider.GetWeather().ToObservable())
                  .ObserveOnDispatcher()
                  .Subscribe(data => DataContext = data);
              disposables.Add(weather);
            };
    
            Unloaded += (sender, args) => disposables.Dispose();
        }
    }
