		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged (e);
			Control.FocusChange += (sender, evt) => {
                new Handler().PostDelayed(delegate
                {
                    var imm = (InputMethodManager)Control.Context.GetSystemService(Context.InputMethodService);
                    var result = imm.HideSoftInputFromWindow(Control.WindowToken, 0);
                }, 500L);
			};
		}
