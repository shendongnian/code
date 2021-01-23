    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Table_Name", typeof(string));
            table.Columns.Add("Column_Name", typeof(string));
            table.Rows.Add("SALES   ", "PROD_ID     ");
            table.Rows.Add("SALES   ", "SALES_ID    ");
            table.Rows.Add("CUSTOMER", "CUST_ID     ");
            table.Rows.Add("CUSTOMER", "CUST_NAME   ");
            table.Rows.Add("PRODUCT ", "PRODUCT_ID  ");
            table.Rows.Add("PRODUCT ", "PRODUCT_NAME");
            DataTable newTable = RotateDataTable(table, 0);
            foreach (DataRow dataRow in newTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write("#" + item + "# ");
                }
                Console.WriteLine();
            }
        }
        private static DataTable RotateDataTable(DataTable table, int groupingColumn)
        {
            var grouped = table.AsEnumerable()
                    .GroupBy(dr => dr.ItemArray[groupingColumn])
                    .Select(grouping => grouping.ToList())
                    .ToList();
            int count = grouped.Count;
            int rowCount = grouped[0].Count;
            if (!grouped.All(g => g.Count == rowCount))
                throw new Exception("Unexpected input");
            DataTable newTable = new DataTable();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                    newTable.Columns.Add(table.Columns[j].ColumnName + (i + j));
            }
            for (int i = 0; i < rowCount; i++)
                newTable.Rows.Add(newTable.NewRow());
            for (int i = 0; i < count; i++)
            {
                var list = grouped[i].ToList();
                for (int j = 0; j < rowCount; j++)
                {
                    for (int k = 0; k < list[j].ItemArray.Length; k++)
                    {
                        string field = list[j].Field<string>(k);
                        int index = (i * table.Columns.Count) + k;
                        newTable.Rows[j].SetField<string>(index, field);
                    }
                }
            }
            return newTable;
        }
    }
