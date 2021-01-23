    if (con.State != ConnectionState.Open)
       con.Open();
    Boolean genderval = false;
    SqlCeCommand gendercmnd = new SqlCeCommand(@"SELECT Gender FROM Std_info WHERE Std_id='" + TextBox1.Text + "'", con);
    gendercmnd.Connection.Open(); // Open the connection using the gendercmd string.
    sqlReader = gendercmnd.ExecuteReader(); // Execute the read, which returns an SqlCEDataReader object that we can use to access the data. 
    genderval = Convert.ToBoolean(gendercmndResult);
                if (genderval == true)
                    Convert.ToBoolean(radioButton1.Checked);
                else
                    Convert.ToBoolean(radioButton2.Checked);  
    con.Close();
