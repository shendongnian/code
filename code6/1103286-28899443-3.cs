    using Android.Widget;
    using Android.OS;
    using Android.Gms.Maps;
    using Android.Gms.Maps.Model;
    
    namespace MapTest
    {
    	[Activity (Label = "MapTest", MainLauncher = true, Icon = "@drawable/icon")]
    	public class MainActivity : Activity
    	{
    		GoogleMap map;
    
    		protected override void OnCreate (Bundle bundle)
    		{
    			base.OnCreate (bundle);
    			SetContentView (Resource.Layout.Main);
    			MapFragment mapFrag =  FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
    			map = mapFrag.Map;
    			Button button = FindViewById<Button> (Resource.Id.myButton);
    			button.Click += delegate {
    				LoadPoints();
    			};
    		}
    
    		void LoadPoints() 
    		{
    			var points = new List<Tuple<string, double, double>> () {
    				Tuple.Create("London", 51.50000, -0.11670),
    				Tuple.Create("New York", 40.75170, -73.99420),
    				Tuple.Create("Hong Kong", 21.75000, 115.00000),
    				Tuple.Create("Berlin", 52.51670, 13.33330),
    				Tuple.Create("Buenos Aires", -34.33320, -58.49990),
    				Tuple.Create("Cairo, Egypt", 30.00000, 31.28330),
    				Tuple.Create("Geneva", 46.23330, 6.06670),
    				Tuple.Create("Singapore",  1.36670, 103.75000),
    				Tuple.Create("Washington", 38.89750, -77.00920),
    				Tuple.Create("Canberra", -35.35000, 149.16670)
    			};
    
    			var fiveRandomPointsFromList = points.OrderBy(x => Guid.NewGuid()).Take(5);
    
    			if (map != null)
    			{
    				RunOnUiThread (new Action (delegate { map.Clear (); }));
    
    				foreach(var point in fiveRandomPointsFromList)
    				{
    					var markerOpt1 = new MarkerOptions()
    						.SetTitle(point.Item1)
    						.SetPosition(new LatLng(point.Item2, point.Item3))
    						.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(
    						 BitmapDescriptorFactory.HueMagenta));
    					RunOnUiThread (new Action (delegate { map.AddMarker(markerOpt1); }));
    				}
    			}
    		}
    	}
    }
