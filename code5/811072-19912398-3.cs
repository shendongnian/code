	public class GoogleMapActivity : Android.Support.V4.App.FragmentActivity
	{
		private Android.Gms.Maps.GoogleMap _mapView;
		private Android.Gms.Maps.SupportMapFragment _fragment;
		
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.GoogleMap);
			var mapOptions = new Android.Gms.Maps.GoogleMapOptions()
				.InvokeMapType(Android.Gms.Maps.GoogleMap.MapTypeNormal)
				.InvokeZoomControlsEnabled(false)
				.InvokeCompassEnabled(true);
			var fragTx = SupportFragmentManager.BeginTransaction();
			var mapFragment = Android.Gms.Maps.SupportMapFragment.NewInstance(mapOptions);
			fragTx.Add(Resource.Id.mapView, mapFragment, "mapView");
			fragTx.Commit();
		}
		
		protected override void OnResume()
		{
			base.OnResume();
			
			_fragment = ((Android.Gms.Maps.SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.mapView));
			_mapView = _fragment.Map;
		}
	}
