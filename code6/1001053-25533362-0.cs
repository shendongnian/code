    private static DataTable GetCustomer()
    {
         DataTable table = new DataTable();
         DataColumn id = table.Columns.Add(@"Id", typeof(int));
    
         table.Columns.Add(@"Name", typeof(string));
         table.PrimaryKey = new DataColumn[] { id };
         table.Rows.Add(new object[] { 1, @"John" });
         return table;
    }
