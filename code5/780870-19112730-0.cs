	public void dofinish(string url)
	{
		// Bring the other activity into focus.
		var activity2 = new Intent (this, typeof(MainActivity));
		activity2.AddFlags (ActivityFlags.SingleTop | ActivityFlags.ClearTop);
		activity2.PutExtra("targeturl", url);
		StartActivity(activity2);
		// Close this activity.
		Finish();
	}
