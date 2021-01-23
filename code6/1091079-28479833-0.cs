    string selectQuery = "select field1,field2,field3 from mytable where offerMadeBy=@param";
    MySqlConnection sqlCOnnect = new MySqlConnection(RootDBConnection.myConnection);
    MySqlCommand sqlCmd = new MySqlCommand(selectQuery,sqlCOnnect);
    sqlCmd.Parameters.AddWithValue("@param", cbox1.Text.ToString());
    try { 
           sqlCOnnect.Open()
           using (sqlCOnnect)
           {
            ....
           }
          }
