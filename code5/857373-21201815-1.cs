    con.Open();
    OleDbDataReader DR1 = Comm1.ExecuteReader();
    if (DR1.Read())
    {
       textBox1.Text = (DataExtensions.GetSafeString(DR1, "COLUMN"));
       var val = (DataExtensions.GetSafeString(DR1, "COLUMN"));
       if (val == "Yes")
       {
           radioButton1.Checked;
       }
       if (val == "No")
       {
           radioButton2.Checked;
       }
    }
    con.Close();
