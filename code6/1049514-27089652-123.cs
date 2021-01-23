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
            UpdateGUIMethod(gui, ".");
            System.Threading.Thread.Sleep(51);
        }
    }
    void UpdateGUIMethod(MainWindow gui, string text)
    {
        gui.Dispatcher.Invoke(() =>
        {
            txt.Text += text;
        });
    } 
