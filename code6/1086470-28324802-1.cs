    DataTable dt = null;
    var rows = ds.Tables[4].AsEnumerable()
        .Where(x => ((DateTime)x["EndDate"]).Date >= DateTime.Now.Date);
    
	if (rows.Any())
        dt = rows.CopyToDataTable();
