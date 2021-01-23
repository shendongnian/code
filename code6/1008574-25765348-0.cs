    var myDataSet = new DataSet();
    
    myDataSet.Tables.Add();
    myDataSet.Tables[0].Columns.Add("Date", typeof (DateTime));
    myDataSet.Tables[0].Columns.Add("Value", typeof(string));
    
    myDataSet.Tables[0].Rows.Add(DateTime.Today, "1");
    myDataSet.Tables[0].Rows.Add(new DateTime(2014, 1, 1), "2");
    myDataSet.Tables[0].Rows.Add(new DateTime(2013, 12, 31), "3");
    
    var dateFrom = new DateTime(2013, 1, 1);
    var dateTo = DateTime.Today;
    
    var query = string.Format("Date >= '{0}' AND Date <= '{1}'", dateFrom, dateTo);
    var resultRows = myDataSet.Tables[0].Select(query);
