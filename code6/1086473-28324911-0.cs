    var rowSources = ds.Tables[4].AsEnumerable()
               .Where(x => ((DateTime)x["EndDate"]).Date >= DateTime.Now.Date);
    if(rowSources.Any())
    {
       DataTable dt = sources.CopyToDataTable()
       ... code that deals with the datatable object
    }
    else
    {
       ... error message ?
    }
