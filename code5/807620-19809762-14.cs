		//Number Dependency Property
		public int Number
		{
			get { return (int)GetValue(NumberProperty); }
			set { SetValue(NumberProperty, value); }
		}
		public static readonly DependencyProperty NumberProperty =
			DependencyProperty.Register("Number", typeof(int), typeof(Day), new UIPropertyMetadata(1));
		//IsLastDayOfMonth Dependency Property
		public bool IsLastDayOfMonth
		{
			get { return (bool)GetValue(IsLastDayOfMonthProperty); }
			set { SetValue(IsLastDayOfMonthProperty, value); }
		}
		public static readonly DependencyProperty IsLastDayOfMonthProperty =
			DependencyProperty.Register("IsLastDayOfMonth", typeof(bool), typeof(Day), new UIPropertyMetadata(false));
		public bool IsFirstDayOfMonth
		{
			get { return (bool)GetValue(IsFirstDayOfMonthProperty); }
			set { SetValue(IsFirstDayOfMonthProperty, value); }
		}
		public static readonly DependencyProperty IsFirstDayOfMonthProperty =
			DependencyProperty.Register("IsFirstDayOfMonth", typeof(bool), typeof(Day), new UIPropertyMetadata(false));
