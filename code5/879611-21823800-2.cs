    int rowIndex = -1;
    int dateColumnIndex = DataGridView1.Columns["e_date"].Index;// < replace with your actual date column name
    foreach(DataGridViewRow row in DataGridView1.Rows)
    {
        DateTime colDate = row.Cells[dateColumnIndex ].Value as DateTime;
        if(colDate != null && colDate.Date == DateTime.Today )
        {
           row.Selected = True; 
           break;
        }
    }
