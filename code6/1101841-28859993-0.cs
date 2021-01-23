		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged (e);
			Control.FocusChange += (sender, evt) => {
				var imm = (InputMethodManager)Control.Context.GetSystemService(Android.Content.Context.InputMethodService);
				var result = imm.HideSoftInputFromWindow(Control.WindowToken, 0);
			};
		}
