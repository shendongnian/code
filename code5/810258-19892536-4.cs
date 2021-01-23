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
