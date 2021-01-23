    public List<shuffleDataList> pullShuffledData(SqlDataReader rdr)
    {
        List<shuffleDataList> callList = new List<shuffleDataList>();
    
        if (rdr != null)
        {
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    callList.Add(new shuffleDataList()
                         {
                             Name = rdr.GetString(0), //Name column
                             Local = rdr.GetString(1), //Local column
                             Employee_Number = rdr.GetString(2), //Employee_Number column
                             Employee_Name = rdr.GetString(3), //Employee_Name column
                         });
                }
                sqlConn.Close();
            }
            else
            {
                return null;
            }
        }
        return callList; 
    }
