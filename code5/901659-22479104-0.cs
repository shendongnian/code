	public class VM1 : DependencyObject
	{
		public VM1()
		{
			//as you see the Child is instantiated when VM1 is instantiated
			Child = new VM2();
		}
		public VM2 Child
		{
			get { return (VM2)GetValue(ChildVmProperty); }
			set { SetValue(ChildVmProperty, value); }
		}
		public static readonly DependencyProperty ChildVmProperty =
			DependencyProperty.Register("Child", typeof(VM2), typeof(VM1), new UIPropertyMetadata(null));
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(VM1), new UIPropertyMetadata(null));
	}
	public class VM2 : DependencyObject
	{
		public string InnerText
		{
			get { return (string)GetValue(InnerTextProperty); }
			set { SetValue(InnerTextProperty, value); }
		}
		public static readonly DependencyProperty InnerTextProperty =
			DependencyProperty.Register("InnerText", typeof(string), typeof(VM2), new UIPropertyMetadata(null));
	}
