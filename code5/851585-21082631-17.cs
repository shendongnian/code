	static async Task TestAsync()
	{
		await Task.Delay(1000);
	}
	void Form_Load(object sender, EventArgs e)
	{
		TestAsync().Wait(); // dead-lock here
	}
