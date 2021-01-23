    using System.Threading.Tasks;
    public static void Main()
    {
                var table = new DataTable("MyTable");
                table.Columns.Add("Col1", typeof(string));
                table.Rows.Add("abc,def");
                table.Rows.Add("ghi,jkl");
    
                Parallel.ForEach(table.AsEnumerable(), (row => row.SetField("Col1", row.Field<string>("Col1").Replace(",", ", "))));    
    }
