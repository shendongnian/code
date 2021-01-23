    private static DispatcherTimer myClickWaitTimer = 
        new DispatcherTimer(
            new TimeSpan(0, 0, 0, 1), 
            DispatcherPriority.Background, 
            mouseWaitTimer_Tick, 
            Dispatcher.CurrentDispatcher);
	private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		// Stop the timer from ticking.
		myClickWaitTimer.Stop();
		Trace.WriteLine("Double Click");
		e.Handled = true;
	}
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		myClickWaitTimer.Start();
	}
	private static void mouseWaitTimer_Tick(object sender, EventArgs e)
	{
		myClickWaitTimer.Stop();
		// Handle Single Click Actions
		Trace.WriteLine("Single Click");
	}
