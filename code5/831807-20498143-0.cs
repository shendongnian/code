        /// <summary>
        /// Nvest Development Solutions
        /// Export the SQL data into a comma separated file
        /// </summary>
        /// <param name="ConnectionString">Valid SQL Server connection string</param>
        /// <param name="Sql">A valid SQL statement</param>
        /// <param name="TimeOut">A timeout specified in seconds</param>
        /// <returns>A stringbuilder with comma separated data</returns>
        public static StringBuilder ExportToCSVFormat(string ConnectionString, string Sql, int TimeOut = 30)
        {
            StringBuilder csv = new StringBuilder();
            string s = "";
            DataTable dt = SQL.BuildTableFromSQL(ConnectionString, Sql, TimeOut);
            //Add the titles
            foreach (DataColumn col in dt.Columns)
            {
                s += "\"" + col.ColumnName + "\", ";
            }
            if (s.Length > 1)
            {
                s = s.Remove(s.Length - 2);
            }
            csv.AppendLine(s);
            //Add the data
            foreach (DataRow row in dt.Rows)
            {
                object[] param = new object[dt.Columns.Count];
                int j = 0;
                s = "";
                foreach (DataColumn col in dt.Columns)
                {
                    s += "{" + j + "";
                    if (col.DataType == typeof(int) || col.DataType == typeof(long) || col.DataType == typeof(double))
                    {
                        s += ":0},";
                    }
                    else
                    {
                        s += ":},";
                    }
                    param[j] = row[col.ToString()];
                    j++;
                }
                csv.AppendLine(string.Format(s, param));
            }
            return csv;
        }
    }
