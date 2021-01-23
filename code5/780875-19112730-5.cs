	[Activity (Label = "WebPage", Theme = "@android:style/Theme.NoTitleBar")]
	public class WebPage : Activity
	{
		WebView web_view;
		public delegate void OnLinkSelectedHandler (string url);
		private class HelloWebViewClient : WebViewClient
		{
			private OnLinkSelectedHandler linkSelected;
			public HelloWebViewClient(OnLinkSelectedHandler handler)
			{
				linkSelected = handler;
			}
			public override bool ShouldOverrideUrlLoading (WebView view, string url)
			{
				view.LoadUrl (url);
				if (url == "http://stackoverflow.com/about")
				{
					this.linkSelected (url);
				}
				return true;
			}
		}
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
		public string targeturl;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.WebViewTest);
			web_view = FindViewById<WebView> (Resource.Id.webView1);
			web_view.LoadUrl ("http://stackoverflow.com");
			// Pass the callback used to close this activity.
			web_view.SetWebViewClient (new HelloWebViewClient (this.dofinish));
		}
	}
