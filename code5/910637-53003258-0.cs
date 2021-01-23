	public MainWindow()
	{
		InitializeComponent();
		OpenConnection();
	}
	public SqlConnection con = new SqlConnection
	{
		ConnectionString = ConfigurationManager.ConnectionStrings["databaseName"].ConnectionString
	};
	public void OpenConnection()
	{
		try
		{
			con.Open();
		}
		catch (SqlException ex)
		{
			MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
			/// If you want the program to exit completely
			/// Environment.Exit(0);
		}
	}
