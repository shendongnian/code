    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    Calendar cal = dfi.Calendar;
    int week = cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
    var rowsFiltered = from row in table.AsEnumerable()
                       let date = row.Field<DateTime>("Date")
                       where date.Year == DateTime.Today.Year 
                       && week == cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)
                       select row;
    DataTable tblFiltered = table.Clone(); // empty table with same columns
    foreach (DataRow row in rowsFiltered)
        tblFiltered.ImportRow(row);
    gvweeksch.DataSource = tblFiltered;
    gvweeksch.DataBind();
