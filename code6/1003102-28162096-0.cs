    //in class:
    private MKMapView _map;
    private MKMapViewDelegate _mapDelegate;
    
     public override void ViewDidLoad()        {
                base.ViewDidLoad();
    
                //Init Map
                _map = new MKMapView
                {
                    MapType = MKMapType.Standard,
                    ShowsUserLocation = true,
                    ZoomEnabled = true,
                    ScrollEnabled = true
                };
    
                //Create new MapDelegate Instance
                _mapDelegate = new MapDelegate();
    
                //Add delegate to map
                _map.Delegate = _mapDelegate;
    
                View = _map;
    
                //Create Directions
                CreateRoute();
            }
    
    //in createroute
      //Create Origin and Dest Place Marks and Map Items to use for directions
                //Start at Xamarin SF Office
                var orignPlaceMark = new MKPlacemark(new CLLocationCoordinate2D(37.797530, -122.402590), null);
                var sourceItem = new MKMapItem(orignPlaceMark);
    
                //End at Xamarin Cambridge Office
                var destPlaceMark = new MKPlacemark(new CLLocationCoordinate2D(42.374172, -71.120639), null);
                var destItem = new MKMapItem(destPlaceMark);
    var request = new MKDirectionsRequest
                {
                    Source = sourceItem,
                    Destination = destItem,
                    RequestsAlternateRoutes = true
                };
    
                var directions = new MKDirections(request);
    
     directions.CalculateDirections((response, error) =>
                {
                    if (error != null)
                    {
                        Console.WriteLine(error.LocalizedDescription);
                    }
                    else
                    {
                       //Add each Polyline from route to map as overlay
                        foreach (var route in response.Routes)
                        {
                            _map.AddOverlay(route.Polyline);
                        }
                    }
                });
    
    class MapDelegate : MKMapViewDelegate
      {
            //Override OverLayRenderer to draw Polyline from directions
            public override MKOverlayRenderer OverlayRenderer(MKMapView mapView, IMKOverlay overlay)
                {
                    if (overlay is MKPolyline)
                    {
                        var route = (MKPolyline)overlay;
                        var renderer = new MKPolylineRenderer(route) { StrokeColor = UIColor.Blue };
                        return renderer;
                    }
                    return null;
                }
            }
    
        }
