    public static readonly DependencyProperty RotateToValueProperty =
			DependencyProperty.Register("RotateToValue", typeof (double), typeof (MainWindow), new PropertyMetadata(default(double)));
		public double RotateToValue
		{
			get { return (double)GetValue(RotateToValueProperty); }
			set { SetValue(RotateToValueProperty, value); }
		}
