    public List<List<string > > retTable()
        {
            
            DataTable dt = new DataTable();
            adap.Fill(dt);
            List<string  > lstRow = new List<string >();
            List<List<string>> lstTable = new List<List<string>>();
            int c = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                lstRow.Clear();  // remove all elements
                for (int i = 0; i < c; i++)
                {
                    lstRow.Add(row[i].ToString().Replace("\r\n", string.Empty));
                }
                lstTable.Add(lstRow );
            }
            
            return lstTable ;
        }
