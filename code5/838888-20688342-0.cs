    var xdoc = XDocument.Load(path_to_xml);
    DataTable dt = new DataTable();
    // Get all column names from document
    var columnNames = xdoc.Root.Descendants("str")
                          .Select(s => (string)s.Attribute("name"))
                          .Distinct();
    // create column for each unique str
    foreach(var columnName in columnNames)
       dt.Columns.Add(new DataColumn(columnName));
    foreach(var doc in xdoc.Root.Elements("doc"))
    {
       var row = dt.NewRow();
       // fill row values
       foreach(var str in doc.Elements("str"))
           row[(string)str.Attribute("name")] = (string)str;
       dt.Rows.Add(row); // add row
    }
    
