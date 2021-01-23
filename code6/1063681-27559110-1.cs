    public List<String> getListFromColumnAsDATE(String columnName, String database)
    {
            myCommand = new SqlCommand("SELECT [Date] = convert(char(10), getdate(), 103) FROM Weekly_Tannery_Data", myConnection);
            List<String> graphList = new List<String>();
            myConnection.Open();
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                graphList.Add(myReader.GetString(0));
            }
            myConnection.Close();
            return graphList;
    }
