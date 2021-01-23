            public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LoadWatcher();
        }
        private void LoadWatcher()
        {
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                watcher.MovementThreshold = 20;
                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
                watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            }
            watcher.Start();
        }
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            myMap.SetView(e.Position.Location, 10);
        }
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    statusTextBlock.Text = "location is not functioning on this device";
                    break;
                case GeoPositionStatus.Initializing:
                    statusTextBlock.Text = "Initializing";
                    break;
                case GeoPositionStatus.NoData:
                    statusTextBlock.Text = "location data is not available.";
                    break;
                case GeoPositionStatus.Ready:
                    statusTextBlock.Text = "location data is available.";
                    break;
            }
        }
        private void map1_Tap(object sender, GestureEventArgs e)
        {
            var position = e.GetPosition(myMap);
            var geoCoordinate = new GeoCoordinate();
            geoCoordinate = myMap.ViewportPointToLocation(position);
            OpenDirectionTo(geoCoordinate);
        }
        private void OpenDirectionTo(GeoCoordinate locationY)
        {
            BingMapsDirectionsTask directionTask = new BingMapsDirectionsTask();
            directionTask.End = new LabeledMapLocation("Your tapped location", locationY);
            directionTask.Show();
        }
    }
