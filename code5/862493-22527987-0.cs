    AutoCompleteStringCollection autoComp = new AutoCompleteStringCollection();
    try
    {
     SqlConnection con = new SqlConnection(@"server=localhost;database=sakila;userid=root;password=password;");
     SqlCommand cmd = new SqlCommand();
     cmd.Connection = con;
     cmd.CommandType = CommandType.Text;
     cmd.CommandText = "select distinct CategoryName FROM Category";
     con.Open();
     SqlDataReader rea = cmd.ExecuteReader();
     if (rea.HasRows == true)
     {
	    while (rea.Read())
        {
	      autoComp.Add(rea.GetString(0));
	    }
	    rea.Close();
     }
     catch (SqlException err)
     {
       MessageBox.Show("Error: " + err.ToString());
     }
     this.txtCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
     this.txtCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
     this.txtCategory.AutoCompleteCustomSource = autoComp;
