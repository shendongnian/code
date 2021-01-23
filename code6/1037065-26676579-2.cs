    string _CurrentActionType = "";
    
    SqlConnection _Connection = new SqlConnection("connection string");
    SqlCommand _Command = new SqlCommand(
    							@"SELECT *
    								FROM HOLIDAY_DATE_TABLE
    								WHERE ACTION_TYPE <> '-'
    								ORDER BY ACTION_TYPE ASC;",
                                _Connection
                              );
    SqlDataReader _Reader = null;
    
    try
    {						  
       _Connection.Open();
    	
       _Reader = _Command.ExecuteReader();
    	
       if (_Reader.HasRows())
       {
          using (StreamWriter writer =
                new StreamWriter(
                   @"C:\BillingExport\EXPORTS\EFTHLDAY.TABLE.TYPE08.TRANSACTIONS.txt"))
          {
             while (_Reader.Read())
             {
                // assuming [ACTION_TYPE] field is 5th column; adjust accordingly
                if (_Reader.GetString(4) != _CurrentActionType)
                {
                   _CurrentActionType = _Reader.GetString(4);
                   writer.WriteLine(_CurrentActionType);
                }
    
                writer.WriteLine(
                   "{0}                  {0}         {1}                 {2}",
                   _Reader.GetInt32(1), _Reader.GetInt32(2), _Reader.GetInt32(3));
             }
          }
       }
    }
    finally
    {
       _Reader.Close();
       _Connection.Close();
    }
