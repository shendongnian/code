    private void comboBox_stockIndex_SelectedIndexChanged(object sender, EventArgs e)
    {
         foreach (DataRow db in LoadTickers().Rows)
         {
            if (comboBox_stockIndex.SelectedItem.ToString() == db["Symbol"].ToString())
            {
                 (dataGridView_flaggedComments.DataSource as DataTable).DefaultView.RowFilter = string.Format("Tickers_Ticker_ID = '{0}'", db["Ticker_ID"].ToString());
            }
         }
         PopulateStockDatesIndex((dataGridView_flaggedComments.DataSource as DataTable).DefaultView.RowFilter);
    }
    private void PopulateStockDatesIndex(string rowFilter)
    {
      comboBox_stockDates.Items.Clear();
      comboBox_stockDates.Items.Add("Choose to Filter");
      comboBox_stockDates.FormatString = "dd-MM-yyyy";
      DataTable dt_filterDate = (DataTable)(dataGridView_flaggedComments.DataSource);
      dt_filterDate.DefaultView.RowFilter = rowFilter;
      foreach (DataRow row in dt_filterDate.Rows)
      {
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
      }
  } 
