    private void Button01_click(object sender, EventArgs e)
    {
		//reinintialize your timer to stop the old one.
		timer2 = new Stopwatch();
		
		var startTime = DateTime.Now;
		Button01.BackColor = Color.FromName("Green");
		Button01textleft.BackColor = Color.FromName("Green");
		timer2.Tick += (obj, args) =>
		{
			var now = DateTime.Now;
			var timeDifference = (TimeSpan.FromMinutes(1) - (now - startTime));
			var stringValue = timeDifference.ToString("hh\\:mm\\:ss");
			Button01text1.Text = stringValue;
			Button01textleft.Text = stringValue;
			
			if (timeDifference <= TimeSpan.FromSeconds(30))
			{
				Button01.BackColor = Color.FromName("Orange");
				Button01textleft.BackColor = Color.FromName("Orange");
			}
			else if (timeDifference <= TimeSpan.FromSeconds(0))
			{
				Button01.BackColor = Color.FromName("Red");
				Button01textleft.BackColor = Color.FromName("Red");
				timer2.Stop();
			}
		};
		timer2.Enabled = true;
	}
