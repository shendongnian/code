	private void fillMake()
	{
		string str = "Select Item_Make from Item Where Item_Name = @item_name";
		using (SqlConnection con = new SqlConnection(@"Data Source=ashish-pc\;Initial Catalog=HMS;Integrated Security=True"))
		{
			using (SqlCommand cmd = new SqlCommand(str, con))
			{
				cmd.Parameters.AddWithValue("@item_name", comboBoxName.Text);
				using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
				{
					DataTable dtItem = new DataTable();
					adp.Fill(dtItem);
					comboBoxMake.DataSource = dtItem;
					comboBoxMake.DisplayMember = "Item_Make";
					comboBoxMake.ValueMember = "Item_Make";
					comboBoxMake.SelectedIndex = -1;
					comboBoxMake.Text = "Select";
				}
			}
		}
	}
