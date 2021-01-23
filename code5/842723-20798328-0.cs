    cmd = new SqlCommand("select Video_Name,subject from Videos where subject like @vdnam",con);
    cmd.Parameters.AddWithValue("@vdnam", "%" + VdName + "%");
    
    if (dr.HasRows)
    {
    while (dr.Read())
    {
    a.Add(dr[0].ToString());
    }
    foreach (string n in a)
    {
    comboBox1.Items.Add(n);
    }
    MessageBox.Show("Search succeded");
    }
