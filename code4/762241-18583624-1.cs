	public partial class TestControl : UserControl
	{
		protected override void OnInitialized(EventArgs e)
		{
			InitializeComponent();
			base.OnInitialized(e);
		}
		public static readonly DependencyProperty TestValueProperty = DependencyProperty.Register(
			"TestValue",
			typeof(string),
			typeof(TestControl),
			new UIPropertyMetadata("Original Value"));
		public string TestValue
		{
			get { return (string)GetValue(TestValueProperty); }
			set { SetValue(TestValueProperty, value); }
		}
	}
