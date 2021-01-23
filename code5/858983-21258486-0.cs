    DateTime maxDate = DateTime.MinValue;
    foreach (DataRow row in dt.Rows)
    {
        DateTime dateTime = DateTime.Parse(row.Field<string>("DateColumn"));
        if (dateTime > maxDate) maxDate = dateTime;
    }
