    namespace ConsoleApplication8
    {
        public class Test
        {
            public int ID;
            public string Descript;
            public int? Rate;
        }
        class Program
        {
            public static DataTable ToDataTable(List<Test> items)
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Descript", typeof(string));
                table.Columns.Add("Rate", typeof(int));
    
                foreach (Test item in items)
                {
                    DataRow row = table.NewRow();
                    row["ID"] = item.ID;
                    row["Descript"] = item.Descript;
                    if (item.Rate.HasValue) row["Rate"] = item.Rate;
                    else row["Rate"] = DBNull.Value;
    
                    table.Rows.Add(row);
                }
    
                return table;
            }
    
            static void Main(string[] args)
            {
                var list = new List<Test>();
                list.Add(new Test() { ID = 4, Descript = "1", Rate = 1 });
                list.Add(new Test() { ID = 5, Descript = "2", Rate = 2 });
                list.Add(new Test() { ID = 6, Descript = "3", Rate = 3 });
                list.Add(new Test() { ID = 7 });
                list.Add(new Test() { ID = 8, Descript = "3", Rate = 3 });
                list.Add(new Test() { ID = 9, Descript = "3", Rate = 3 });
    
                var Context = new Entities();
    
                SqlConnection ec = (SqlConnection)Context.Database.Connection;
    
                var copy = new SqlBulkCopy(ec, SqlBulkCopyOptions.CheckConstraints, null);
    
                copy.DestinationTableName = "dbo.TestSparse";
                copy.ColumnMappings.Add("ID", "ID");
                copy.ColumnMappings.Add("Descript", "Descript");
                copy.ColumnMappings.Add("Rate", "Rate");
    
                ec.Open();
                var table = ToDataTable(list);
                copy.WriteToServer(table);
                copy.Close();
            }
        }
    }
