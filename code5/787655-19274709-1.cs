    public ActionResult Index(string q = "default")
    {
        var Results = new List<Result>();
        var cManager = new CSearchManager();
        ISearchQueryHelper cHelper = cManager.GetCatalog("SYSTEMINDEX").GetQueryHelper();
        cHelper.QuerySelectColumns = "\"System.ItemNameDisplay\",\"System.FileExtension\",\"System.ItemFolderPathDisplay\"";
        cHelper.QueryMaxResults = 50;
        using (var cConnnection = new OleDbConnection(cHelper.ConnectionString))
        {
            cConnnection.Open();
            using (var cmd = new OleDbCommand(cHelper.GenerateSQLFromUserQuery(q), cConnnection))
            {
                if (cConnnection.State == System.Data.ConnectionState.Open)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Results.Clear();
                        while (!reader.IsClosed && reader.Read())
                        {
                            Results.Add(new Result() { Name = reader[0].ToString(), Ext = reader[1].ToString(), Path = reader[2].ToString() });
                        }
                        reader.Close();
                    }
                }
            }
            cConnnection.Close();
        }
        ViewBag.Results = Results;
        return View();
    }
