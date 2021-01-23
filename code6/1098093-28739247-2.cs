	public class AccountDialogViewController : DialogViewController
	{
		public AccountDialogViewController () : base(new RootElement("Account settings"), true)
		{				
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var btnUpdatePassword = UIButton.FromType(UIButtonType.RoundedRect);
			btnUpdatePassword.SetTitle("Save new password", UIControlState.Normal);
			btnUpdatePassword.Frame = new RectangleF(0, 0, 320, 44);
			btnUpdatePassword.TouchUpInside += delegate(object sender, EventArgs e) {
				var alert = new UIAlertView("Test", "msg", null, "Cancel", null);
				alert.Show();
			};
			Root.Add(new Section ("General") {
				new EntryElement("Username", "type...", "Test"),
				new EntryElement("E-mail", "type...", "Test"),
				new RootElement ("Change password") {
					new Section (null, btnUpdatePassword) {
						new EntryElement("New password", null, null, true),
						new EntryElement("Confirm", null, null, true)				
					}
				},
				new StringElement ("Logout", delegate {
					var alert = new UIAlertView("Are you sure?", "Tapping Yes will log you out of your account", null, "Cancel", "Yes");
					alert.Show();
				})
			});
		}
	}
