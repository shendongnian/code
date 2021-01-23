    public override void ViewDidLoad()
    {
        var customDelegate = new CustomerMapViewDelegate();
        customDelegate.OnRegionChanged += TheMapView_OnRegionChanged;
        TheMapView.Delegate = customDelegate;
    }
    public void TheMapView_OnRegionChanged(object sender, MKMapViewChangeEventArgs e)
    {
        var latitude = TheMapView.Region.Center.Latitude;
        var longitude = TheMapView.Region.Center.Longitude;
        // Map change logic goes here
    }
    public class CustomMapViewDelegate : MKMapViewDelegate
    {
        public event EventHandler<MKMapViewChangeEventArgs> OnRegionChanged;
        public override void RegionChanged(MKMapView mapView, bool animated)
        {
            if (OnRegionChanged != null)
            {
                OnRegionChanged(mapView, new MKMapViewChangeEventArgs(animated));
            }
        }
    }
