	public class MyControl : SomeOtherControl
	{
		public MyControl()
		{
			DefaultStyleKey = typeof(MyControl);
		}
		public static readonly DependencyProperty VisibilityChangedProperty = DependencyProperty.Register(
			"VisibilityChanged",
			typeof(string),
			typeof(MyControl),
			new PropertyMetadata("VisibilityChanged event handler"));
		public event VisibilityChangedEventHandler VisibilityChanged;
		public delegate void VisibilityChangedEventHandler(object sender, EventArgs e);
		public new Visibility Visibility
		{
			get { return base.Visibility; }
			set
			{
				if (base.Visibility == value) return;
				base.Visibility = value;
				VisibilityChanged(this, new EventArgs());
			}
		}
	}
