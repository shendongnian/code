	public partial class MainWindow : Window
	{
		int _pIndex = 0;
		List<IItem> list = new List<IItem>();
        
		public MainWindow()
		{
			InitializeComponent();
			list[_pIndex].Completed += (s, e) =>
			{
				_pIndex++;
				_pIndex %= list.Count;
				Next();
			};
		}
		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			list = new List<IItem>()
			{
				new ItemImage() { Duration = TimeSpan.FromSeconds(5), Name = "Image1" },
				new ItemImage() { Duration = TimeSpan.FromSeconds(3), Name = "Image2" },
				new ItemImage() { Duration = TimeSpan.FromSeconds(5), Name = "Image3" },
				new ItemImage() { Duration = TimeSpan.FromSeconds(7), Name = "Image4" }
			};
			Next();
		}
		void Next()
		{
            var tb = new TextBlock();
            tb.Text = ((IItem)list[_pIndex]).Name;
            StackPanel1.Children.Add(tb);
			list[_pIndex].Show();
		}
	}
