    DataTable dt2 = new DataTable();
    dt2.Columns.Add("Name", typeof(string));
    IEnumerable<DateTime> distinctDates = dt1.AsEnumerable().Select(row => (DateTime)row["Date"]).Distinct().OrderBy(date => date);
    foreach (var distinctDate in distinctDates)
    {
        dt2.Columns.Add(distinctDate.ToString("MM__dd__yy", CultureInfo.InvariantCulture), typeof(int));
    }
    IEnumerable<string> distinctNames = dt1.AsEnumerable().Select(row => (string)row["Name"]).Distinct().ToList();
    foreach (var distinctName in distinctNames)
    {
        DataRow outputRow = dt2.NewRow();
        outputRow["Name"] = distinctName;
        IEnumerable<Tuple<int, DateTime>> inputRowsForName = dt1.AsEnumerable()
            .Where(row => (string)row["Name"] == distinctName)
            .Select(row => new Tuple<int, DateTime>((int)row["Count"], (DateTime)row["Date"]));
        foreach (var inputRowForName in inputRowsForName)
        {
            string columnName = inputRowForName.Item2.ToString("MM__dd__yy", CultureInfo.InvariantCulture);
            outputRow[columnName] = inputRowForName.Item1;
        }
        dt2.Rows.Add(outputRow);
    }
    GridView.ItemsSource = dt2.DefaultView;
