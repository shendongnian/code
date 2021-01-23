    public DataTable CopyTable (DataTable TextFileTable)
            {
                DataTable tblFormat = new DataTable();
                    tblFormat.Columns.Add("ColumnA");
                    tblFormat.Columns.Add("ColumnB");
                    tblFormat.Columns.Add("ColumnC");
                    tblFormat.Columns.Add("ColumnD");
                    tblFormat.Columns.Add("ColumnE");
                    for (int i = 0; i < TextFileTable.Rows.Count; i++)
                    {
                        tblFormat.Rows.Add(new string[] { TextFileTable.Rows[i][0].ToString(), TextFileTable.Rows[i][1].ToString(),
                        TextFileTable.Rows[i][2].ToString(), TextFileTable.Rows[i][8].ToString(), TextFileTable.Rows[i][9].ToString() });
                    }
               
                return tblFormat;
            }
