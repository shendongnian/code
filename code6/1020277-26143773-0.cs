    public Connexion()
    {
       Connexion.IsEnabled = false;
       var ignore = InitAsync();
    }
    private async Task InitAsync()
    {
                Debug.WriteLine("Start");
                Geolocator geolocator = null;
                geolocator = new Geolocator() { DesiredAccuracy = 50};
                var result = await geolocator.GetPositionAsync(8000);
                    Debug.WriteLine(string.Format("Latitude : {0} Longitude : {1}",       result.Latitude, result.Longitude)); //Visual Studio's debugger indicate this line with the exception
                Connexion.IsEnabled = true;
     }
                
