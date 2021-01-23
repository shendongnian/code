	void UpdateWindow(string text)
	{
        //safe call
		Dispatcher.Invoke(() =>
		{
			txt.Text += text;
		});
	}
