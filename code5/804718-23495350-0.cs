    	btnDone = FindViewById<Button> (Resource.Id.btnDone);
			LocationManager LC=(LocationManager) GetSystemService(Context.LocationService);
			Criteria criteria=new Criteria();
			string	provider=LC.GetBestProvider(criteria, true);
			Location loc=LC.GetLastKnownLocation(provider);
    `btnDone.Click += delegate {
    OnLocationChanged(loc);
    }
     
    // outside OnCreate
    public void OnLocationChanged(Location location) {
    			
			double  lattitude = location.Latitude;
			double longitude = location.Longitude;
			Toast.MakeText (this, "Lattitude and Longitude is "+lattitude.ToString()+" and "+longitude.ToString(), ToastLength.Long).Show ();
		}
