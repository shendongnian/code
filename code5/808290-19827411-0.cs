    public JsonResult getAutoCompletedata(string query)
    {
        var query = from p in dt.AsEnumerable() //dt is the datatable
                            where p.Field<string>("code") == query
                            select new
                            {
                                value = p.Field<string>("yourColumnName"),
                                lable= p.Field<string>("YourAnotherColumnName")                         
                            }.ToList();
        return Json(query, JsonRequestBehavior.AllowGet);
    }
