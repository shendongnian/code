    spojeni.Open();
    //change your query string there was an error in it
    string sql_combobox = "SELECT column FROM table ORDER BY nazev ASC";
    SqlCommand combobox = new SqlCommand(sql_combobox, spojeni);
    try
    {
       SqlDataReader dr = combobox.ExecuteReader();
       while (dr.Read())
       {
           if (!dr.IsDBNull(0))
           {
              comboBox1.Items.Add(dr.GetString(0));
           }
       }
       dr.Close();
       dr.Dispose();
       spojeni.Close();
    }
