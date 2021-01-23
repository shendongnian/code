    cmd = new SqlCommand("select Video_Name,subject from Videos where subject like @vdnam",con);
    cmd.Parameters.AddWithValue("@vdnam", "%" + VdName + "%");
    
    if (dr.HasRows)
    {
    while (dr.Read())
    {
    a.Add(dr[0].ToString());
    }
    comboBox1.Datasource= a.List();
    
    MessageBox.Show("Search succeded");
    }
