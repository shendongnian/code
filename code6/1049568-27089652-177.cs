	private async void Button_Click_3(object sender, RoutedEventArgs e)
	{
        txt.Text = "started";
		await Task.Run(()=> HeavyMethod(this));
        txt.Text = "done";
    }
    internal void HeavyMethod(MainWindow gui)
    {
        while (stillWorking)
        {
            window.Dispatcher.Invoke(() =>
            {
                // UI operations go inside of Invoke
                txt.Text += ".";
            });
            
            // CPU-bound or I/O-bound operations go outside of Invoke
            System.Threading.Thread.Sleep(51);
        }
    }
