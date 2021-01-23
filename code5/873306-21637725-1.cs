    public MyViewModel()
	{
		for (int y = 0; y < 10; y++)
			for (int x = 0; x < 10; x++)
				this.Items.Add(new Widget {
					X = x * 20,
					Y = y * 20,
					Width = 10,
					Height = 10,
					Color = Color.FromArgb(255, (byte)(x * 20), (byte)(y * 20), 0)
				});
	}
