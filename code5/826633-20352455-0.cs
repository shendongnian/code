    for (int i = 0; i < sampleDataSet.Tables[0].Rows.Count; i++) 
    {
        for (int j = 0; j < sampleDataSet.Tables[0].Columns.Count; j++)
        {
            if (sampleDataSet.Tables[0].Rows[i][j].ToString() == "01/01/1754 00:00:00") 
            {
                sampleDataSet.Tables[0].Rows[i][j] = "NULL";
            }
        }
    }
