    private GoogleMap NativeMap { get;set;}
	protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		base.OnElementPropertyChanged (sender, e);
		if (e.PropertyName.Equals ("VisibleRegion")) {
			var targetElement = (Android.Gms.Maps.MapView)Control;
			if (NativeMap == null) {
				targetElement.GetMapAsync (this);
			}
		}
	}
