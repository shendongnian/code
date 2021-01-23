    public IEnumerable<int> GetCallsToRescheduleListPreviousDays()
    {
        using (var cmd = new MySqlCommand
        ( 
           "`phytel`.`spPhy_GetCallsToRescheduleListPreviousDays`", 
           (MySqlConnection) DatabaseConnection,  workerTransaction
        )
        {
          cmd.CommandType = CommandType.StoredProcedure;
          using (var reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
               while( reader.Read())
               {
                   yield return reader.GetInt32(0);
               }
            }
          }
        }
    }
