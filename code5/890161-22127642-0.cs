		public ICommand Select
		{
			get { return (ICommand)GetValue(SelectProperty); }
			set { SetValue(SelectProperty, value); }
		}
		public static readonly DependencyProperty SelectProperty =
			DependencyProperty.Register("Select", typeof(ICommand), typeof(MainWindow), new UIPropertyMetadata(null));
		public bool SelectServEnabled
		{
			get { return (bool)GetValue(SelectServEnabledProperty); }
			set { SetValue(SelectServEnabledProperty, value); }
		}
		public static readonly DependencyProperty SelectServEnabledProperty =
			DependencyProperty.Register("SelectServEnabled", typeof(bool), typeof(MainWindow), new UIPropertyMetadata(true));
