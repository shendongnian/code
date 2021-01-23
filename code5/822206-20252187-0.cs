    //........ retrieving radioButton value ....... 
    if (conn.State != ConnectionState.Open) 
          conn.Open(); 
    try { 
           Boolean genderval = SqlCeCommand gendercmnd = new SqlCeCommand(@"SELECT Gender FROM Std_Info     WHERE Std_id='" + TextBox1.Text + "'", con); 
     
    genderval = (Boolean)gendercmnd.ExecuteScalar(); 
    if (genderval == true) 
        Convert.ToBoolean(radioButton1.Checked=true); 
    else 
        Convert.ToBoolean(radioButton2.Checked = true); 
    conn.Close(); 
         } 
    catch (Exception ex)
         {
              MessageBox.Show(ex.Message);
         }
