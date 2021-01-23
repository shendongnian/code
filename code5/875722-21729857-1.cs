    List<MyClass> assets = new List<MyClass>();
    var fileName = string.Format("C:\\HAM.xlsx");
    var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", fileName);
    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
    var ds = new DataSet();
    adapter.Fill(ds, "hardcatAssets");
    DataTable data = ds.Tables["hardcatAssets"];
    foreach (DataRow row in data.Rows)
    {
        MyClass asset = new MyClass();
        foreach(PropertyInfo pinfo in asset.GetType().GetProperties())
        {
            pinfo.SetValue(asset, row.Field<string>(this.SplitCamelCase(pinfo.Name)));
        }
        assets.Add(asset);
    }
    return assets;
