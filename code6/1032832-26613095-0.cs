	public Form1()
	{
		InitializeComponent();
		tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
	}
	private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
	{
		SendKeys.Send("\t");
	}
