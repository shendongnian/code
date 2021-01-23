    var start = new DateTime(2013, 9, 23);
    var end = new DateTime(2013, 10, 5);
    double daysBefore = (start - new DateTime(start.Year, 1, 1)).TotalDays;
    int
        weekNumber = (int)Math.Ceiling(daysBefore / 7), // Start Day week number
        currentYear = start.Year; // used to check for a new year
    for (var dt = start; dt <= end; dt = dt.AddDays(7))
    {
        if (dt.Year > currentYear)
        {
            currentYear = dt.Year;
            weekNumber = 1;
        }
        
        dataGridView1.Columns.Add(new DataGridViewColumn
        {
            HeaderText = (weekNumber++).ToString(),
            CellTemplate = new DataGridViewTextBoxCell()
        });
    }
