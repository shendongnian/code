    DataSet ds = GetTheData("Jan 2014");
    DataTable dt = ds.Tables[0];
    
    EnumerableRowCollection<DataRow> q = dt.AsEnumerable().Where(a => a.Field<String>("SomeColumn1") == "Jan 2014")
                                                          .Select(a => a.Field<String>("SomeColumn2"));
    
    DropDownCheckBoxes1.DataSource = q.AsDataView();
    DropDownCheckBoxes1.DataBind();
