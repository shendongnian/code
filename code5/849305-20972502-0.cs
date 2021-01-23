    DataTable table = new DataTable();
    table.Columns.Add("Persian date 1");
    table.Columns.Add("Persian date 2");
    
    var persCal = new System.Globalization.PersianCalendar();
    foreach(DataRow row in dataTable1.Rows)
    {
        DateTime dt1 = row.Field<DateTime>(0);
        DateTime dt2 = row.Field<DateTime>(1);
        int year1 = persCal.GetYear(dt1);
        int month1 = persCal.GetMonth(dt1);
        int day1 = persCal.GetDayOfMonth(dt1);
        int year2 = persCal.GetYear(dt2);
        int month2 = persCal.GetMonth(dt2);
        int day2 = persCal.GetDayOfMonth(dt2);
        string persDate1 = string.Format("{0}-{1}-{2}", year1, month1, day1);
        string persDate2 = string.Format("{0}-{1}-{2}", year2, month2, day2);
        table.Rows.Add(persDate1, persDate2);
    }
   
