	public class MainVm : DependencyObject
	{
		/// <summary>
		/// Gets or sets a fully bindable value that indicates MyText
		/// </summary>
		public string MyText
		{
			get { return (string)GetValue(MyTextProperty); }
			set { SetValue(MyTextProperty, value); }
		}
		public static readonly DependencyProperty MyTextProperty=
			DependencyProperty.Register("MyText", typeof(string), typeof(MainVm),
			new PropertyMetadata("default value here"));
		/// <summary>
		/// Gets or sets a fully bindable value that indicates MyProp
		/// </summary>
		public float MyProp
		{
			get { return (float)GetValue(MyPropProperty); }
			set { SetValue(MyPropProperty, value); }
		}
		public static readonly DependencyProperty MyPropProperty =
			DependencyProperty.Register("MyProp", typeof(float), typeof(MainVm),
			new PropertyMetadata(0f,//default value (MUST be the same type as MyProp)
				//property changed callback
				(d, e) => 
				{
					var vm = (MainVm)d;
					var val = (float)e.NewValue;
					vm.MyText = val.ToString();
				}, 
				//coerce value callback
				(d, v) => 
				{
					var vm = (MainVm)d;
					var val = (float)v;
					//prevents from having negative value
					if (val < 0f) return 0f;
					return v;
				}));
		public ObservableCollection<CountryVm> AllCountries { get { return _allCountries; } }
		private ObservableCollection<CountryVm> _allCountries = new ObservableCollection<CountryVm>();
	}
