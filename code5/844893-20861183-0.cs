    var table = new DataTable();
    
    var fileContents = File.ReadAllLines("yourFile");
    
    var splitFileContents = (from f in fileContents select f.Split(':')).ToArray();
    
    int maxLength = (from s in splitFileContents select s.Count()).Max();
    
    for (int i = 0; i < maxLength; i++)
    {
        table.Columns.Add();
    }
    
    foreach (var line in splitFileContents)
    {
        DataRow row = table.NewRow();
        row.ItemArray = (object[])line;
        table.Rows.Add(row);
    }
