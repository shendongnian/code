     public DataTable DataTable
        {
            get
            {
                DataTable table = new DataTable();
                table.Columns.Add("abc");
                table.Columns.Add("qrt");
                table.Columns.Add("xyz");
                table.Rows.Add(1, 6, 11);
                table.Rows.Add(2, 7, 12);
                table.Rows.Add(3, 8, 13);
                table.Rows.Add(4, 9, 14);
                table.Rows.Add(5, 10, 15);
                return table;
            }
        }
