            string xml = @"
                <results>
                    <result>
                        <title>Application Developer</title>
                        <date>Thu, 30 Jan 2014 14:09:00 GMT</date>
                        <expired>false</expired>
                    </result>
                    <result>
                        <title>Incomplete</title>
                        <date></date>
                        <expired></expired>
                    </result>
                    <result>
                        <title>Professional Time-waster</title>
                        <date>Fri, 31 Jan 2014 18:35:00 GMT</date>
                        <expired>false</expired>
                    </result>
                </results>";
            XDocument xDoc = XDocument.Parse(xml);
            // Create a DataTable that mimics the Table Valued Parameter structure.
            DataTable dt = new DataTable();
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Expired", typeof(bool));
            // Just make the code cleaner
            Func<string, string> getString = s => string.IsNullOrEmpty(s) ? null : s;
            Func<string, DateTime?> getDateTime = d => string.IsNullOrEmpty(d) ? null : (DateTime?)DateTime.Parse(d);
            Func<string, bool?> getBool = b => string.IsNullOrEmpty(b) ? null : (bool?)Convert.ToBoolean(b);
            // here we populate the table variable, using above Funcs<> to handle nulls
            // This code does assume that your date format, when present, will always be parseable.
            xDoc.Descendants("result")
                .ToList()
                .ForEach(r =>
                    dt.Rows.Add(
                        getString(r.Element("title").Value),
                        getDateTime(r.Element("date").Value),
                        getBool(r.Element("expired").Value)
                    )
                );
            // Now all that's left is to call the stored procedure and pass the DataTable to it
            string connString = "your connection string";
            using(var conn = new SqlConnection(connString))
            using(var cmd = new SqlCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertXmlResultsByTable";
                SqlParameter tableParameter = cmd.Parameters.AddWithValue("XmlResultTable", dt);
                tableParameter.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
