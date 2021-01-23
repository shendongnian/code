    static DataTable GetTable()
    {
    List<Object> yourObjectList	=  // This is assuming you have a list of objects
    var _firstObject = yourObjectList.First();
    var table = new DataTable();
    // Do this multiple times for each parameter you have. 
    table.Columns.Add(_firstObject.ParamaterName, typeof(string));
    foreach(var obj in yourObjectList)
    {
	table.Rows.Add(obj.ParamaterName, obj.ParamaterName2, etc);
    }
	return table;
    }
