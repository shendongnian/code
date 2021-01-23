     public IEnumerable<string> QueryWindowsDesktopSearch(string directory)
        {
            List<string> extensions = new List<string>
            { "docx","xlsx","pptx","docm","xlsm","pptm","dotx","xltx","xlw","potx","ppsx","ppsm","doc","xls","ppt","doct","xlt","xlm","pot","pps"};
            string userQuery = "*";
            Boolean fShowQuery = true;
            List<string> list = new List<string>();
            CSearchManager manager = new CSearchManager();
            CSearchCatalogManager catalogManager = manager.GetCatalog("SystemIndex");
            CSearchQueryHelper queryHelper = catalogManager.GetQueryHelper();
            queryHelper.QueryWhereRestrictions = string.Format("AND (\"SCOPE\" = 'file:{0}')", directory);
            if (extensions != null)
            {
                queryHelper.QueryWhereRestrictions += " AND Contains(System.ItemType,'";
                bool fFirst = true;
                foreach (string ext in extensions)
                {
                    if (!fFirst)
                    {
                        queryHelper.QueryWhereRestrictions += " OR ";
                    }
                    queryHelper.QueryWhereRestrictions += "\"" + ext + "\"";
                    fFirst = false;
                }
                queryHelper.QueryWhereRestrictions += "') ";
            }
            string sqlQuery = queryHelper.GenerateSQLFromUserQuery(userQuery);
            using (OleDbConnection connection = new OleDbConnection(queryHelper.ConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand(sqlQuery, connection))
                {
                    connection.Open();
                    OleDbDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var file = dataReader.GetString(0);
                        if (file != null)
                        {
                            list.Add(file.Replace("file:", ""));
                        }
                    }
                }
            }
            return list;
        }
