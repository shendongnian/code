	public Form1()
	{
		InitializeComponent();
		List<DataTable> dataTable = new List<DataTable>();
		string path = @"server=.\sqlexpress;database=Cities;integrated Security=True;";
		using (SqlConnection con = new SqlConnection(path))
		{
			SqlCommand cmd = con.CreateCommand();
			cmd.CommandText = "select id_city, name from city order by name";
			try
			{
				con.Open();
				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						dataTable.Add(new DataTable()
						{
							id_city = (int)dr["id_city"]
						   ,name = dr["name"] as string
						});
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}
		BindingSource bs = new BindingSource() { DataSource = dataTable };
		comboBox1.ValueMember = "id_city";
		comboBox1.DisplayMember = "name";
		comboBox1.DataSource = bs;
	}
