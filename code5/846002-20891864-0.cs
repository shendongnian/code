	int counter = 0;
	void Timer1_Tick(object sender, EventArgs e)
	{
		progressBar1.PerformStep();
		if(progressBar1.Value == 100)
		{
			Timer.Enabled = false;
			Form1 form1 = new Form1();
			form1.Show();
			this.Hide(); //or Close maybe (test them both)
		}
	}
