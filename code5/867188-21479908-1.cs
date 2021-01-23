    public partial class MyParentWindow : Window
	{
		public MyParentWindow()
		{
			InitializeComponent();
			this.MyButton.DataContext = new ButtonModel();
		}
		private void UserControl_MouseDown_1(object sender, RoutedEventArgs e)
		{
		}
		private void UserControl_MouseDown_2(object sender, RoutedEventArgs e)
		{
		}
		private void UserControl_MouseDown_3(object sender, RoutedEventArgs e)
		{
		}
		private void UserControl_MouseDown_4(object sender, RoutedEventArgs e)
		{
		}
	}
	public class ButtonModel
	{
		public Brush Brush00 { get { return Brushes.Red; } }
		public Brush Brush01 { get { return Brushes.Green; } }
		public Brush Brush10 { get { return Brushes.Blue; } }
		public Brush Brush11 { get { return Brushes.Yellow; } }
	}
