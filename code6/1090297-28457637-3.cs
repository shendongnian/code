    DataTable listOFDates = new DataTable();
    listOFDates.Columns.Add("Dates");
    listOFDates.Columns.Add("Numbers");
    for (int i = 0; i < dates.Count(); i++)
    {
        listOFDates.Rows.Add(dates[i], numbers[i]);
    }
