    public SessionDto GetSessionData(int roomId)
        {
    
            using (var cnn = new SqlConnection(ConnStr))
            {
    			SessionDto sessionDto;
    			
    			string query = @"SELECT SessionID, RoomID, SessionDate, SessionTimeStart, SessionTimeEnd" +
    		   " FROM [Session] " +
    		   " WHERE RoomID = @RoomID " +
    		   " AND SessionDate = cast(getdate() as date) ";
    
    
                cnn.Open();
                using (var cmd = new SqlCommand(query,cnn))
                {
                    cmd.Parameters.Add("@RoomID", SqlDbType.Char).Value = roomId;
    
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
    							sessionDto = new sessionDto{
    								RoomID = rdr.GetString(0),
                                        SessionDate = rdr.GetString(1),
                                        SessionTimeStart = rdr.GetString(2),
    									SessionTimeEnd = rdr.GetString(3)
    							};
                            }
                        }
                    }
                }
            }
            return sessionDto;
        }
