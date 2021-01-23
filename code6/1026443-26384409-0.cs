    public override void LoadView ()
		{
			base.LoadView ();
            CameraPosition camera = CameraPosition.FromCamera (62.3909145, 17.3098496, 15);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			mapView.MyLocationEnabled = true;
            Task.Run(async () => await StageTheView());
			View = mapView;
		}
        private async Task StageTheView()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://www.unikabutiker.nu/api/?function=searchByName&key=kT6zAOpNk21f9UhhNWzVrK8fHjvl22K2imF1aRkvN9aScUOK6v&name=Sundsvall");
                var s = "";
                using (var reader = new StreamReader(await result.Content.ReadAsStreamAsync()))
                {
                    s = await reader.ReadToEndAsync();
                }
                var jsonVal = JsonValue.Parse(s);                          
                for (var i = 0; i < jsonVal["result"].Count; i++)
                {
                    // manipulate UI controls
                    var marker = new Marker()
                    {
                        Title = jsonVal["result"][i]["title"],
                        Snippet = jsonVal["result"][i]["adress"],
                        Position = new CLLocationCoordinate2D(jsonVal["result"][i]["lat"], jsonVal["result"][i]["lng"])
                    };
                    marker.Map = mapView;
                }
            }
        }
