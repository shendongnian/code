    public ActionResult Index(HttpPostedFileBase file)
    {
        var path = Path.Combine(Server.MapPath("~/Files/",file.FileName));
        file.SaveAs(path);
        var connectionString = "";
        if (Path.GetExtension(path).ToLower()==".xslx")
        {
            connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;",path);
        }
        else
        {
            connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", path);
        }
        var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
        var ds = new DataSet();
        adapter.Fill(ds, "customer");
        var customer = ds.Tables["customer"].AsEnumerable();
    }
