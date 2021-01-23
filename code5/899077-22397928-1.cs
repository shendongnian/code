    for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
    {
        DemoSearchList.StartDate.Add(Convert.ToString(DS.Tables[0].Rows[i][0]));
        DemoSearchList.EndDate.Add(Convert.ToString(DS.Tables[0].Rows[i][1]));
    }
