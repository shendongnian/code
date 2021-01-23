        static void Main(string[] args)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("A");
            tbl.Columns.Add("B");
            
            var p = from DataColumn col in tbl.Columns select col.ColumnName;
            
            foreach(string a in p)
            {
                Console.WriteLine(a);
            }
        }
