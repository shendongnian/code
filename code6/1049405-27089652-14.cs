	void UpdateWindow(string text)
	{
		Dispatcher.Invoke(() =>
		{
			txt.Text += text;
		});
	}
