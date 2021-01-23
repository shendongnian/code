    for (int i = 0; i < table.Rows.Count; i++)
    {
        chart1.Series.Add(table.Rows[i][0].ToString());
    }
    for (int i = 0; i < table.Rows.Count; i++)
    {
        chart1.Series[i].Points.AddXY(table.Rows[i][0].ToString(),  
                                      Convert.ToInt32(table.Rows[i][1]));
    }
