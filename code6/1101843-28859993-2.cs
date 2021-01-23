		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.Click += (sender, evt) => {
					new Handler().Post(delegate
						{
							var imm = (InputMethodManager)Control.Context.GetSystemService(Android.Content.Context.InputMethodService);
							var result = imm.HideSoftInputFromWindow(Control.WindowToken, 0);
							Console.WriteLine(result);
						});
				};
			
				Control.FocusChange += (sender, evt) => {
					new Handler().Post(delegate
						{
							var imm = (InputMethodManager)Control.Context.GetSystemService(Android.Content.Context.InputMethodService);
							var result = imm.HideSoftInputFromWindow(Control.WindowToken, 0);
							Console.WriteLine(result);
						});
				};
			}
		}
