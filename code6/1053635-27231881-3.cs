       private void fillName()
       {
           SqlConnection con = new SqlConnection(@"Data Source=ashish-pc\;Initial Catalog=HMS;Integrated Security=True");
           con.Open();
           string str = "Select Item_Name from Item";
           SqlCommand cmd = new SqlCommand(str, con);
           SqlDataAdapter adp = new SqlDataAdapter(str, con);
           DataTable dtItem = new DataTable();
           adp.Fill(dtItem);
           cmd.ExecuteNonQuery();
           comboBoxName.DataSource = dtItem;
           comboBoxName.DisplayMember = "Item_Name";
           comboBoxName.ValueMember = "Item_Make";
       }
