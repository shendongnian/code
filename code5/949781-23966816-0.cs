      public bool CSVFileRead(string fullPathWithFileName, string fileNameModified, string tableName)
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
            string filepath = fullPathWithFileName;
            StreamReader sr = new StreamReader(filepath);
            string line = sr.ReadLine();
            string[] value = line.Split(',');
            DataTable dt = new DataTable();
            DataRow row;
            foreach (string dc in value)
            {
                dt.Columns.Add(new DataColumn(dc));
            }
            while (!sr.EndOfStream)
            {
                //string[] stud = sr.ReadLine().Split(',');
                //for (int i = 0; i < stud.Length; i++)
                //{
                //    stud[i] = stud[i].Replace("\"", "");
                //}
                //value = stud;
                value = sr.ReadLine().Split(',');
                if (value.Length == dt.Columns.Count)
                {
                    row = dt.NewRow();
                    row.ItemArray = value;
                    dt.Rows.Add(row);
                }
            }
            SqlBulkCopy bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock);
            bc.DestinationTableName = tableName;
            bc.BatchSize = dt.Rows.Count;
            con.Open();
            bc.WriteToServer(dt);
            bc.Close();
            con.Close();
            return true;
        }
