	public class InlineMedia: InlineUIContainer
	{
		public InlineMedia()
		{
		}
		public InlineMedia(UIElement childUIElement) : base(childUIElement)
		{
			UpdateChildSource();
		}
		public InlineMedia(UIElement childUIElement, TextPointer insertPosition)
			: base(childUIElement, insertPosition)
		{
			UpdateChildSource();
		}
		public static readonly DependencyProperty ChildSourceProperty = DependencyProperty.Register
		(
			"ChildSource",
			typeof(string),
			typeof(InlineMedia),
			new FrameworkPropertyMetadata(null, OnChildSourceChanged));
		public string ChildSource
		{
			get
			{
				return (string)GetValue(ChildSourceProperty);
			}
			set
			{
				SetValue(ChildSourceProperty, value);
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new UIElement Child
		{
			get
			{
				return base.Child;
			}
			set
			{
				base.Child = value;
				UpdateChildSource();
			}
		}
		public void UpdateChildSource()
		{
			IsInternalChildSourceChange = true;
			try
			{
				ChildSource = Save();
			}
			finally
			{
				IsInternalChildSourceChange = false;
			}
		}
		public string Save()
		{
			if(Child == null)
			{
				return null;
			}
			using(var stream = new MemoryStream())
			{
				XamlWriter.Save(Child, stream);
				stream.Position = 0;
				using(var reader = new StreamReader(stream, Encoding.UTF8))
				{
					return reader.ReadToEnd();
				}
			}
		}
		public void Load(string sourceData)
		{
			if(string.IsNullOrEmpty(sourceData))
			{
				base.Child = null;
			}
			else
			{
				using(var stream = new MemoryStream(Encoding.UTF8.GetBytes(sourceData)))
				{
					var child = XamlReader.Load(stream);
					base.Child = (UIElement)child;
				}
			}
		}
		private static void OnChildSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var img = (InlineMedia) sender;
			if(img != null && !img.IsInternalChildSourceChange)
			{
				img.Load((string)e.NewValue);
			}
		}
		protected bool IsInternalChildSourceChange { get; private set; }
	}
