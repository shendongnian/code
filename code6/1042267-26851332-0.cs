    DataView dv_filterDate = (DataView)dataGridView_flaggedComments.DataSource.DefaultView;
    dv_filterDate.RowFilter = string.Format("Tickers_Ticker_ID = '{0}'", db["Ticker_ID"].ToString()););
    foreach (DataRowView rowview in dv_filterDate)
    {
        DataRow row = rowview.Row;
        for (int i = 0; i < dataGridView_flaggedComments.Rows.Count - 1; i++)
        {
            if (dataGridView_flaggedComments.Rows[i].Cells["Comments_Date"].Value.ToString() != "")
            {
                string date = row.Field<DateTime>(1).ToString("dd-MM-yyyy");
                if (!comboBox_stockDates.Items.Contains(date))
                {
                    comboBox_stockDates.Items.Add(date);
                }
            }
        }
    }`
