        private void initMap()
        {
            myMap.Credentials = "---";
            myMap.ZoomLevel = 9.5;
            myMap.Center = new Bing.Maps.Location(35.1,33.3);
            myMap.ShowNavigationBar = false;
            myMap.MapType = Bing.Maps.MapType.Aerial;
            
            Pushpin pushpin = new Pushpin();
            MapLayer.SetPosition(pushpin, new Location(35.34028, 33.31917));
            myMap.Children.Add(pushpin);
            pushpin.Tapped += pushpin_Tapped;
        }
        void pushpin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Pushpin tmp = (Pushpin)sender;
            tmp.Text = "ABC";
        }
