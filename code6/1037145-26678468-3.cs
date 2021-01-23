    public override void OnResume ()
	{
		base.OnResume ();
		if (cancelToken != null && cancelToken.CanBeCanceled && cancelSource != null) {
			cancelSource.Cancel ();
		}
     }
    public override void OnPause()
	{
		base.OnPause ();
		if (cancelToken != null && cancelToken.CanBeCanceled && cancelSource != null) {
			cancelSource.Cancel ();
		}
	}
