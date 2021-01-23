    KeyValuePair<string, string> names = new getTableValues();
    string colHead = names.Key; // contains the column heading
    string tabName = name.Value; // contains the Table name
    string tableName = "get" + tabName + "Table()" // produce a getTable name
    var table = typeof(Initialise).GetMethod(tableName).Invoke(null, null); // Initialise is a class for getting tables.
    var data = ((IQueryable)t).Where(string.Format("!{0}.Equals(@0) && !{0}.Equals(@1)", colHead), null, "")
                              .OrderBy("code")
                              .Select(string.Format("new(code as Code,Convert.ToDecimal({0}) as Property )",colHead));
    DataGridView1.DataSource = data;
