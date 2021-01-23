    public class MapiOS : ViewRenderer<MyMap, MKMapView>
    {
      protected override void OnElementChanged (ElementChangedEventArgs<MyMap> e)
      {
        base.OnElementChanged (e);
        var map = e.NewElement; // Remember to check for null
        var locations = map.Locations;
        // Do what you want with locations
    
        var cmd = Map.PinTapped; // Send this along to MyMapDelegate
        var nativeMap = new MKMapView(); // Initiate with relevant parameters
        SetNativeControl(nativeMap)
        MyMapDelegate myMapDelegate = new MyMapDelegate (cmd); // Change constructor here
        nativeMap.Delegate = myMapDelegate;
        nativeMap.AddAnnotation(new MKPointAnnotation (){
            Title=list[0].nome,
            Coordinate = new CLLocationCoordinate2D (42.364260, -71.120824)
        });
      }
