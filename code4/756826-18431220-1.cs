    public List<List<string >> retListTable()
        {
            
            DataTable dt = new DataTable();
            adap.Fill(dt);
            
            List<List<string>> lstTable = new List<List<string>>();
            
            foreach (DataRow row in dt.Rows)
            {
                List<string> lstRow = new List<string>();
                foreach (var item in row.ItemArray )
                {
                    lstRow.Add(item.ToString().Replace("\r\n", string.Empty));
                }
                lstTable.Add(lstRow );
            }
            
            return lstTable ;
        }
