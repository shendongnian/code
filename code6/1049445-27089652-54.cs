	void UpdateWindow(string text)
	{
        //safe call
		Dispatcher.Invoke(() =>
		{
			txt.Text += text;
		});
        //or simply
		txt.Text += text;
	}
