    DateTime selectedDate = 
      new DateTime(DateTime.Now.Year, Calndar.SelectedDate.Month, Calndar.SelectedDate.Day);
    DataSet ds = (DataSet)Session["Calendar"];
    IEnumerable<DataRow> selectedRows = ds.Tables[0].AsEnumerable().
      Where(row => (row.Field<DateTime>("HolidayDate") == selectedDate));
    foreach (DataRow selectedRow in selectedRows) 
    ...
