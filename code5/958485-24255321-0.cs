	[Activity (Label = "LinkToDesktop", MainLauncher = true)]
	[IntentFilter (new[] { Intent.ActionSend }, Categories = new[] {
		Intent.CategoryDefault,
		Intent.CategoryBrowsable
	}, DataMimeType = "text/plain")]
	public class MainActivity : Activity
		{
		protected override void OnCreate (Bundle bundle)
			{
			base.OnCreate (bundle);
			if (!String.IsNullOrEmpty (Intent.GetStringExtra (Intent.ExtraText)))
				{
				string subject = Intent.GetStringExtra (Intent.ExtraSubject) ?? "subject not available";
				Toast.MakeText (this, subject, ToastLength.Long).Show ();
				}
			}
		}
