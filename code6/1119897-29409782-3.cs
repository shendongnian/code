    Series S = chart1.Series.Add("names");
    for (int i = 0; i < table.Rows.Count; i++)
    {
        S.Points.AddXY(table.Rows[i][0].ToString(), Convert.ToInt32(table.Rows[i][1]));
    }
