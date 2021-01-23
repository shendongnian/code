        static void Main(string[] args)
        {
            Hashtable sqlDatatypeholder = new Hashtable();
            //Sql Connection      
            string _mySqlUrl = "connection is correct and works in other test apps";
            string _mySqlQuery = "Query is here, it works fine in SQL management studio";
            SqlConnection conn = new SqlConnection(_mySqlUrl);
            SqlCommand comm = new SqlCommand(_mySqlQuery, conn);
            DataTable _tempTable = new DataTable();
            using (conn)
            {
                SqlCommand command = new SqlCommand(_mySqlQuery, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                _tempTable.Load(reader);
                reader.Close();
                if (_tempTable != null && _tempTable.Rows.Count > 0)
                {
                    for (int v = 0; v < _tempTable.Columns.Count; v++)
                    {
                        DataColumn dc = _tempTable.Columns[v];
                        sqlDatatypeholder.Add(dc.ColumnName.ToString(), Convert.ToString(reader.GetSqlValue(v).GetType()));
                    }
                    foreach (DictionaryEntry hr in sqlDatatypeholder)
                    {
                        Console.WriteLine(hr.Key + " " + hr.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Connection Open - No rows found.");
                }                
            }
        }
