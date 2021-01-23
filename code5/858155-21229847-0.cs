    double[] selectedHours = hours.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries)
        .Select(str => {
            str = str.Trim();
            double hour;
            bool isDouble = double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out hour);
            return new { str, isDouble, hour };
        })
        .Where(h => h.isDouble)
        .Select(h => h.hour)
        .ToArray();
    var q = from row in dt.AsEnumerable()
            join hour in selectedHours
            on row.Field<double?>("Hours") equals hour 
            select row;
    var dataSource = dt.Clone(); // empty
    if (q.Any())
        dataSource = q.CopyToDataTable();
