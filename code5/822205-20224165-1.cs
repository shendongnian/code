    if (con.State != ConnectionState.Open)
       con.Open();
    Boolean genderval = false;
    String gendercmndResult = null;
    SqlCeCommand gendercmnd = new SqlCeCommand(@"SELECT Gender FROM Std_info WHERE Std_id='" + TextBox1.Text + "'", con);
    gendercmnd.Connection.Open(); // Open the connection using the gendercmd string.
    sqlReader = gendercmnd.ExecuteReader(); returns an SqlCEDataReader object that we can use to access the data.
    while (sqlReader.Read(){ //While the reader is reading...
        gendercmndResult = (sqlReader.GetString(0)); //Assign the returned value from the SQL server to a string called gendercmndResult
    }
    genderval = Convert.ToBoolean(gendercmndResult); //Now we can cast the string as a bool
                if (genderval == true)
                    Convert.ToBoolean(radioButton1.Checked);
                else
                    Convert.ToBoolean(radioButton2.Checked);  
    con.Close();
