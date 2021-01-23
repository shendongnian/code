    private void LoadComboBox2 ()
            {
                DataRow dr;
    
                SqlConnection con = new SqlConnection(@"Data Source=name;Initial Catalog=dbName;User ID=sa;Password=sa123");
                con.Open();
                SqlCommand cmd = new SqlCommand("select id,name from table where id=@ID", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
    
                dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "--Select--" };
                dt.Rows.InsertAt(dr, 0);
    
                ComboBox2 .ValueMember = "ID";
    
                ComboBox2 .DisplayMember = "Name";
                ComboBox2 .DataSource = dt;
                con.Close();
    
            }
