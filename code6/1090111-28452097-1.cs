    private Window1 myWindow = new Window1();
    private void MyButton_Click(object sender, RoutedEventArgs e)
    {
        // Using a timer to simulate something happening 5 seconds later that would cause dialog state to change
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
        dispatcherTimer.Start();
        // The following line will block until you switch the dialog from modal to non-modal
        myWindow.ShowDialog();            
    }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        (sender as DispatcherTimer).Stop();
        myWindow.Hide();
        myWindow.Show();
    }
