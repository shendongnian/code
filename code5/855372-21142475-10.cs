    for (i = 0; i < infos.Length; i++)
    {
        SqlCommand myCommand = new SqlCommand(
            "INSERT INTO RSS2 (Date, Templow, Temphigh)" +
            "Values ('" + infos[i].Date + "','" + infos[i].TempLow + "','" + infos[i].TempHigh + "')", 
            myConnection);
        myCommand.ExecuteNonQuery();
    }
