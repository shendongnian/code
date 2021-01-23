    //For use with Xamarin.Forms.DependencyService will not be necessary with other IoC containers if not using forms look up Tiny IoC, Unity or one of the other DI containers
    [assembly: Xamarin.Forms.Dependency(typeof(YourNameSpace.Droid.YourClass))] 
    
    public class GoogleMap : FragmentActivity, IMapping, IOnMapClickListener
    
    {
     private GoogleMap mMap;
     private Point lastClickedPoint;
    
    protected void OnCreate()
    {
        base.OnCreate();
        setContentView(some map fragment layout)
    
        //set the map touch listener
    }
    
    private void handletouch()// implementation of IOnMapClickListener Interface
    {
        //google how to get the coordinates in android on a map touch
        lastClickedPoint = new Point();
        lastClickedPoint.lat = args.lat;
        lastClickedPoint.long = args.long;
    }
    private Model<GeoPoint> GetLastTouchCoordinates()
    {
        if(lastclickedPoint != null)
        {
        Model<Geopoint> gp = new Model<Geopoint>();
        gp.latitude = p.latitude;
        gp.longitude = p.longitude;
        return gp;
        }
        else
        {
          return Point with some indication that you have no point
        }
    }
    }
