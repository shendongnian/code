    public static string GetTestValue(DependencyObject element)
		{
			return (string)element.GetValue(TestValueProperty);
		}
		public static void SetTestValue(DependencyObject element, string value)
		{
			element.SetValue(TestValueProperty, value);
		}
		
		public static readonly DependencyProperty TestValueProperty = DependencyProperty.RegisterAttached("TestValue", typeof(string), typeof(MainWindow), new FrameworkPropertyMetadata(null));
		
		private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			TextBlock tb = default(TextBlock);
			for (int i = 10; i <= 15; i++)
			{
				tb = new TextBlock();
				tb.Text = "Text for " + i;
				tb.SetValue(TestValueProperty, "Property For " + i);
				this.cb.Items.Add(tb);
			}
		}
