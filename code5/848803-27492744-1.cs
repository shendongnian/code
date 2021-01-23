    SqlCeCommand cmd = new SqlCeCommand("select company from EMPLOYEES where name = @name");
    cmd.Parameters.AddWithValue("@name",textBox1.Text);
    cmd.Connection = con;
    con.Open();
    
    SqlCeDataReader dr = selectSQL.ExecuteReader();
    while (dr.Read())
      {
        label1.Text = dr["ColumnName"].ToString();
      }
    dr.Close();
    con.Close();
