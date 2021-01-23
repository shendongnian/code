        public partial class MainWindow : Window
	{
		Popup w = new Popup();	
		public MainWindow()
		{
			InitializeComponent();
			w.Height = 200;
			w.Width = 200;
			w.Child = new Rectangle() { Fill = Brushes.Red, Stretch = Stretch.Fill };
			w.Placement = PlacementMode.Right;
			w.PlacementTarget = this;	
		}
		bool canPress = false;		
		private void Storyboard_Completed(object sender, EventArgs e)
		{
			canPress = true;
		}
		bool isMouseDown = false;
		private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (isMouseDown && canPress)
			{
				w.IsOpen = true;
			}
			isMouseDown = false;
		}
		private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			isMouseDown = true;
		}
		private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
		{
			isMouseDown = false;
			canPress = false;
		}
		private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
		{
			w.IsOpen = false;		
		}
	}
      
           
