    var sqlCon= new SqlConnection(Properties.Settings.Default.sString);
    var mySQLCon= new MySqlConnection(Properties.Settings.Default.dString);
    sqlCon.Open();
    mySQLCon.Open();
    var temp = mySQLConn.State.ToString();
    if (sqlCon.State==ConnectionState.Open && temp=="Open")
     {
       MessageBox.Show(@"Connection working.");
     }
    else
     {
      MessageBox.Show(@"Please check connection string");
     }
