    Geolocator geolocator;
    Geoposition geoposition;
    public MainPage()
    {
       this.InitializeComponent();
       geolocator = new Geolocator();
       geolocator.DesiredAccuracyInMeters = 10;
       geolocator.ReportInterval = 0;
       myButton.Click += async (sender, e) =>
           {
               geoposition = await geolocator.GetGeopositionAsync();
               string latitude = geoposition.Coordinate.Latitude.ToString("0.0000000000");
               string Longitude = geoposition.Coordinate.Longitude.ToString("0.0000000000");
               string Accuracy = geoposition.Coordinate.Accuracy.ToString("0.0000000000");
           };
    }
