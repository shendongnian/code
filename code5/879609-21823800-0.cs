    int rowIndex = -1;
    int dateColumnIndex = 3;// < replace with your actual index
    foreach(DataGridViewRow row in DataGridView1.Rows)
    {
        DateTime colDate = row.Cells[dateColumnIndex ].Value as DateTime;
        if(colDate != null && colDate.Date == DateTime.Today )
        {
           row.Selected = True; 
           break;
        }
    }
