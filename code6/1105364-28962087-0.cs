            //file upload path
            var fileName = Path.GetFileName(file.FileName);
            // store the file inside ~/App_Data/uploads folder
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            file.SaveAs(path);
            //Create connection string to Excel work book
            string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;Persist Security Info=False";
            //Create Connection to Excel work book
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            //Create OleDbCommand to fetch data from Excel
            excelConnection.Open();
            DataTable dt = new DataTable();
            dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return null;
            }
            String[] excelSheets = new String[dt.Rows.Count];
            int t = 0;
            //excel data saves in temp file here.
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[t] = row["TABLE_NAME"].ToString();
                t++;
            }
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
            string query = string.Format("SELECT * FROM [{0}]", excelSheets[0]);
            OleDbCommand cmd = new OleDbCommand(query, excelConnection);
            //excelConnection.Open();
            OleDbDataReader dReader;
            dReader = cmd.ExecuteReader();
            SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
            //Give your Destination table name
            sqlBulk.DestinationTableName = "[FSM].[DFS_Akustik]";
            sqlBulk.WriteToServer(dReader);
            excelConnection.Close();
            ViewBag.view_dfs_akustik = dbman.View_DFS_Akustik.ToList();
            return View();
