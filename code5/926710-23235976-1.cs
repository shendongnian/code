    public partial class MainWindow : Window
	{
		public MainWindow ()
		{
			InitializeComponent ();
		}
		private async void Button_Click (object sender, RoutedEventArgs e)
		{
			m1.Content = DateTime.Now.ToString ("HH:mm:ss") + "      Establishing Connection";
			m1.Visibility = Visibility.Visible;
			await Task.Run (() => Thread.Sleep (2000));
			m2.Content = DateTime.Now.ToString ("HH:mm:ss") + "      Connected";
			m2.Visibility = Visibility.Visible;
			await Task.Run (() => Thread.Sleep (2000));
			m3.Content = DateTime.Now.ToString ("HH:mm:ss") + "      Processing";
			m3.Visibility = Visibility.Visible;
			await Task.Run (() => Thread.Sleep (2000));
			m4.Content = DateTime.Now.ToString ("HH:mm:ss") + "      Finished";
			m4.Visibility = Visibility.Visible;
			await Task.Run (() => Thread.Sleep (2000));
		}
	}
