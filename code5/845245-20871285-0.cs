    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    col.Name = "DateCol";
    List<DateTime> dates = new List<DateTime>() { DateTime.Now.AddMonths(-1), DateTime.Now, DateTime.Now.AddMonths(1) };
    //Dates = Dates.OrderBy(x => x).ToList();
    List<string> colSource = dates.Select(x => x.ToString("M/yyyy")).ToList(); 
    col.DataSource = colSource;
    
    dataGridView1.Columns.Add(col);
