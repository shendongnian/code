	public MainWindow()
	{
		try
		{
			InitializeComponent();
		}
		catch (Exception exc)
		{
			MessageBox.Show(exc.ToString());
		}
	}
