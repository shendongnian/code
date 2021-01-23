	void Main()
	{
		var timer = new System.Windows.Forms.Timer();
		timer.Tick += Timer_Tick;
		timer.Interval = 50000;
		timer.Start();
		
		System.Threading.Thread.Sleep(1000);
		timer.Interval = 1000;
	}
	
	private void Timer_Tick(object sender, EventArgs e)
	{
		Console.WriteLine("Tick");
	}
