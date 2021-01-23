    foreach (DataGridViewRow row in datagridview.Rows)
                {
                    //chartBpComplaince.Series.Clear();
                    Series S = chartBpComplaince.Series.Add(row.Cells[2].Value.ToString());
                     S.Points.AddXY(row.Cells[4].Value.ToString(), row.Cells[3].Value.ToString());
                     S.ChartType = SeriesChartType.Column;
                     S.IsValueShownAsLabel = true;
    }
