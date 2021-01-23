	private void fillName()
	{
		string str = "Select distinct Item_Name from Item";
		using (SqlConnection con = new SqlConnection(@"Data Source=ashish-pc\;Initial Catalog=HMS;Integrated Security=True"))
		{
			using (SqlCommand cmd = new SqlCommand(str, con))
			{
				using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
				{
					DataTable dtItem = new DataTable();
					adp.Fill(dtItem);
					comboBoxName.DataSource = dtItem;
					comboBoxName.DisplayMember = "Item_Name";
					comboBoxName.ValueMember = "Item_Name";
				}
			}
		}
	}
