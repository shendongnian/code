	public class Foo : ObservableObject
	{
		public BarViewModel A 
		{
			public const string aPropertyName = "a";
			private Bar _a;
			get
			{
				return _a;
			}
			set
			{
				Set(aPropertyName, ref _a, value);
			}
		}
	}
