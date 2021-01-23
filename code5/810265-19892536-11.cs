		public StackedImageTextCtl()
		{
			InitializeComponent();
			DataContext = this;
		}
		//Text Dependency Property
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(StackedImageTextCtl), new UIPropertyMetadata(null));
		//ImageSource Dependency Property
		public ImageSource ImageSource
		{
			get { return (ImageSource)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}
		public static readonly DependencyProperty ImageSourceProperty =
			DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(StackedImageTextCtl), new UIPropertyMetadata(null));
		//State Dependency Property
		public AddEditDelete State
		{
			get { return (AddEditDelete)GetValue(StateProperty); }
			set { SetValue(StateProperty, value); }
		}
		public static readonly DependencyProperty StateProperty =
			DependencyProperty.Register("State", typeof(AddEditDelete), typeof(StackedImageTextCtl), new UIPropertyMetadata(AddEditDelete.Add));
		public static AddEditDelete GetStackCtlState(DependencyObject obj)
		{
			return (AddEditDelete)obj.GetValue(StackCtlStateProperty);
		}
		public static void SetStackCtlState(DependencyObject obj, AddEditDelete value)
		{
			obj.SetValue(StackCtlStateProperty, value);
		}
		public static readonly DependencyProperty StackCtlStateProperty =
			DependencyProperty.RegisterAttached("StackCtlState", typeof(AddEditDelete), typeof(StackedImageTextCtl), new UIPropertyMetadata(AddEditDelete.Add));
