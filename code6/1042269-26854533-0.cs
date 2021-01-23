    private void PopulateStockDatesIndex()
    {
        comboBox_stockDates.Items.Clear();
        comboBox_stockDates.Items.Add("Choose to Filter");
    
        foreach (DataGridViewRow row in dataGridView_flaggedComments.Rows)
        {
            for (int i = 0; i < dataGridView_flaggedComments.Rows.Count - 1; i++)
            {
                if (dataGridView_flaggedComments.Rows[i].Cells["Comments_Date"].Value.ToString() != "")
                {
                    string str = dataGridView_flaggedComments.Rows[i].Cells["Comments_Date"].Value.ToString();
                    DateTime date = DateTime.ParseExact(str, "dd/MM/yyyy h:mm:ss tt", CultureInfo.GetCultureInfo("en-GB"));
                    if (!comboBox_stockDates.Items.Contains(date.ToString("dd/MM/yyyy")))
                    {
                        comboBox_stockDates.Items.Add(date.ToString("dd/MM/yyyy"));
    
                    }
                    comboBox_stockDates.SelectedIndex = 0;
                }
            }
        }
    }
