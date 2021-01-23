	DispatcherTimer timer = new DispatcherTimer();
	private void Window_Loaded(object sender, RoutedEventArgs e)
	{
		//...
		gifMediaElement.Play();
		timer.Interval = TimeSpan.FromSeconds(5);
		timer.Start();
		timer.Tick += (o, args) =>
		{
			timer.Stop();
			gifMediaElement.Stop();
		};
		//...
