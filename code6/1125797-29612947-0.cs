	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostback)
		{
			// do this only if it's the first request
			rndNum = new Random();
			int inFirst = rndNum.Next(1, 51);
			int inSecond = rndNum.Next(50, 101);
			lblFirst.Text = inFirst.ToString();
			inFirstOne = inFirst;
			lblSecond.Text = inSecond.ToString();
			inSecondOne = inSecond
		}
	}
