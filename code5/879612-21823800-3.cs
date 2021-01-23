    int dateColumnIndex = DataGridView1.Columns["e_date"].Index;// < replace with your actual date column name
    foreach (DataGridViewRow row in DataGridView1.Rows)
    {
        if (row.Cells[dateColumnIndex].Value is DateTime)
        {
            DateTime colDate = (DateTime)row.Cells[dateColumnIndex].Value;
            if (colDate.Date == DateTime.Today)
            {
                row.Selected = true;
                break;
            }
        }                
    }
