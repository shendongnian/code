    public partial class MyTabControl : TabControl
	{
		public static readonly DependencyProperty SelectedBgClrProperty = DependencyProperty.Register("SelectedBgClr",
			typeof(Brush), typeof(MyTabControl), new UIPropertyMetadata(null));
		[Category("Appearance")]
		public Brush SelectedBgClr
		{
			get
			{
				return (Brush)GetValue(SelectedBgClrProperty);
			}
			set
			{
				SetValue(SelectedBgClrProperty, value);
			}
		}
		public MyTabControl()
		{
			InitializeComponent();
		}
	}
