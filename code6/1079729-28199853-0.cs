    //For use with Xamarin.Forms.DependencyService will not be necessary with other IoC containers
    [assembly: Xamarin.Forms.Dependency(typeof(YourNameSpace.Droid.YourClass))] 
    
    public class GoogleMap : FragmentActivity, IMapping, IOnMapClickListener
    
    {
     private GoogleMap mMap;
    
    protected void OnCreate()
    {
        base.OnCreate();
        setContentView(some map fragment layout)
    
        //set the map touch listener
    }
    
    private void handletouch()
    {
        //google how to get the coordinates in android on a map touch
    }
    
    }
