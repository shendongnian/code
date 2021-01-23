		public static BindableProperty StartColorProperty = BindableProperty.Create(nameof(CustomContentPage), typeof(Color), typeof(CustomButton), default(Color), defaultBindingMode: BindingMode.OneWay);
		public Color StartColor
		{
			get { return (Color)GetValue(StartColorProperty); }
			set { SetValue(PaddingProperty, value); }
		}
		public static BindableProperty EndColorProperty = BindableProperty.Create(nameof(CustomContentPage), typeof(Color), typeof(CustomButton), default(Color), defaultBindingMode: BindingMode.OneWay);
		public Color EndColor
		{
			get { return (Color)GetValue(EndColorProperty); }
			set { SetValue(PaddingProperty, value); }
		}
