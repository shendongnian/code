		private Lazy<SomeEnum> _value = new Lazy<SomeEnum>(CostyCalculation);
		private SomeEnum CostyCalculation()
		{
			return SomeEnum.E1;
		}
		public SomeEnum MyVar
		{
			get 
			{
				return _value.Value;
			}
		}
