    OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\myDB.accdb");
    
    OleDbCommand cmd = new OleDbCommand();
    
    cmd.Connection = myConnection;
    cmd.CommandType = CommandType.Text;
    
    myConnection.Open();
    
    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            cmd.Parameters.Clear(); 
            cmd.CommandText = "INSERT INTO xCARRIER (CARRIER_ID, CARRIER_NAME) VALUES (@p1, @p2)";
    
            cmd.Parameters.AddWithValue("@p1", dt.Rows[i].ItemArray.GetValue(0));
            cmd.Parameters.AddWithValue("@p2", dt.Rows[i].ItemArray.GetValue(1));
    
            cmd.ExecuteNonQuery();
        }
    
    myConnection.Close();
