    public void Test(DataTable indata)
            {
                DataTable outdata = new DataTable();
                ArrayList columns = new ArrayList();
    
                // create a outdatatable to contain only distinct coulmn names
                foreach (DataColumn dc in indata.Columns)
                {
                    if (!columns.Contains(dc.ColumnName))
                    {
                        columns.Add(dc.ColumnName);
                        outdata.Columns.Add(dc);
                    }
                }
    
                foreach (DataRow dr in indata.Rows)
                {
                    DataRow outdr = outdata.NewRow();
                    outdr["field_1"] = dr["field_1"] + " " +dr["field_1"]; // dont think it is possible to have two coulmns of same name
                    outdr["field_2"] = dr["field_2"] + " " + dr["field_2"];
                }
            }
