        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            ILog log = log4net.LogManager.GetLogger(typeof(excelTwosheetsBulk1));
            log.Info("Connection to database started.");
            string path = string.Empty;
            SqlConnection con;
            con = new SqlConnection(Properties.Settings.Default.charterConnection);
            //SqlConnection _con = new SqlConnection(con);
            string tableName = string.Empty;
            log.Info("Filepath has to be uploaded....");
            Console.WriteLine("Please enter complete file path including name : ");
            path = Console.ReadLine();
            log.Info("File has uploaded....");
            try
            {
                if (path == "")
                {
                    log.Info("File has not uploaded.");
                    Console.WriteLine("Please upload file path......");
                    Console.ReadLine();
                }
                else
                {
                    log.Info("Binding excel data to datatable event started.");
                    DataSet ds = ReadExcelFile(path);
                    log.Info("Binding excel data to datatable event ended.");
                    for (int tableCount = 0; tableCount < ds.Tables.Count; tableCount++)
                    {
                        if (ds.Tables[tableCount].TableName.Contains("'"))
                        {
                            ds.Tables[tableCount].TableName = ds.Tables[tableCount].TableName.Replace("'", "");
                        }
                        if (ds.Tables[tableCount].TableName.Contains(" "))
                        {
                            ds.Tables[tableCount].TableName = ds.Tables[tableCount].TableName.Replace(" ", "");
                        }
                        if (ds.Tables[tableCount].TableName.EndsWith("$"))
                        {
                            ds.Tables[tableCount].TableName = ds.Tables[tableCount].TableName.Replace("$", "");
                        }
                        if (ds.Tables[tableCount].TableName.EndsWith(" "))
                        {
                            ds.Tables[tableCount].TableName = ds.Tables[tableCount].TableName.Replace(" ", "");
                        }
                    }
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        log.Info("Creation of datatable in database.");
                        string result = string.Empty;
                        int tableCount = CheckTable(ds.Tables[i].TableName, con);
                        if (tableCount > 0)
                        {
                            result = CreateTableStatement(ds.Tables[i].TableName + "_" + DateTime.Now.ToString("MMddyyyy"), ds.Tables[i]);
                        }
                        else
                        {
                            result = CreateTableStatement(ds.Tables[i].TableName, ds.Tables[i]);
                        }
                        con.Open();
                        using (var command = new SqlCommand(result, con))
                        {
                            var r = command.ExecuteNonQuery();
                        }
                        SqlBulkCopy bulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                        bulkCopy.DestinationTableName = ds.Tables[i].TableName;
                        bulkCopy.WriteToServer(ds.Tables[i]);
                        tableName += result + ",";
                        con.Close();
                    }
                    log.Info("Excel data imported successfully into datatable.");
                    Console.WriteLine("Table " + tableName.Trim(',') + " imported successfully.");
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception occoured at : " + ex.Message);
                Console.WriteLine("Table " + "" + " has error while importing.");
            }
            Console.Read();
        }
        private static string CreateTableStatement(string tableName, DataTable table)
        {
            log.Info("Assigning parameters to columns.");
            string sqlsc;
            sqlsc = "CREATE TABLE " + tableName + "(";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
                string columnType = table.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sqlsc += " int ";
                        break;
                    case "System.Int64":
                        sqlsc += " bigint ";
                        break;
                    case "System.Int16":
                        sqlsc += " smallint";
                        break;
                    case "System.Byte":
                        sqlsc += " tinyint";
                        break;
                    case "System.Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "System.DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "System.String":
                    default:
                        sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                        break;
                }
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }
        public static DataSet ReadExcelFile(string path)
        {
            DataSet ds = new DataSet();
            string connString = "";
            try
            {
                if (path.Trim().EndsWith(".xlx"))
                {
                    log.Info("Finding excel type file.");
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                }
                else if (path.Trim().EndsWith(".xlsx"))
                {
                    log.Info("Finding excel type file.");
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1;\"";
                }
                //string connectionString = GetConnectionString(path);
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    // Get all Sheets in Excel File
                    log.Info("Appending names to datatable.");
                    DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    // Loop through all Sheets to get data
                    foreach (DataRow dr in dtSheet.Rows)
                    {
                        log.Info("Binding excel data to datatable in sql.");
                        string sheetName = dr["TABLE_NAME"].ToString();
                        string x = sheetName.Substring(1, sheetName.Length - 2);
                        //string x = sheetName.Trim(' ').ToString();
                        if (!x.EndsWith("$"))
                            continue;
                        // Get all rows from the Sheet
                        cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                        DataTable dt = new DataTable();
                        dt.TableName = sheetName;
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        Console.WriteLine("Binding excel data to datatable.");
                        da.Fill(dt);
                        ds.Tables.Add(dt);
                    }
                    cmd = null;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                log.Info("Error occurred at :" + ex.Message);
                Console.WriteLine("Unable to fetch excel data.");
                Console.ReadLine();
            }
            log.Info("Excel data has binded to datatable.");
            return ds;
        }
        private static int CheckTable(string p, SqlConnection con)
        {
            string result = "SELECT count(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = '" + p + "'";
            con.Open();
            //using (var command = new SqlCommand(result, con))
            //{
            //     var r = command.ExecuteNonQuery();
            //}
            var cmd = new SqlCommand(result, con);
            cmd.CommandText = result;
            Int32 count = (Int32)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        public static string GetConnectionString(string path)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = path;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }
            return sb.ToString();
        }
    }
