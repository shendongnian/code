		public double Test
		{
			get { return (double)GetValue(TestProperty); }
			set { SetValue(TestProperty, value); }
		}
		public static readonly DependencyProperty TestProperty = DependencyProperty.Register(
			"Test",
			typeof(double),
			typeof(MoveMe));
		private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
		{
			Margin = new Thickness(Margin.Left + e.HorizontalChange,0,0,0);
			Test = Margin.Left;
			//or resize ...
		}
