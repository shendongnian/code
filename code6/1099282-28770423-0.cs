    class Program
        {
            private static DataTable Table = new DataTable();
    
            static void Main(string[] args)
            {
                Table.Columns.Add("Col1");
                Table.Columns.Add("Col2");
                Table.Columns.Add("Col3");
                Table.Rows.Add(new object[] { "A", 1, "asd" });
                Table.Rows.Add(new object[] { "A", 0, "qwe" });
                Table.Rows.Add(new object[] { "B", 1, "asd" });
                Table.Rows.Add(new object[] { "B", 1, "qwe" });
                Table.Rows.Add(new object[] { "C", 2, "qwe" });
                Table.Rows.Add(new object[] { "C", 5, "asd" });
    
                Gen(Table);
            }
    
    
            public class Set
            {
                public string A { get; set; }
                public string B { get; set; }
                public object Value { get; set; }
            }
    
    
            public static DataTable Gen(DataTable Tbl)
            {
    
                        
                    
                // Build objects
                var List = new List<Set>();
    
                foreach(DataRow Row in Tbl.Rows)
                {
    
                    List.Add(new Set { A = (String)Row["Col1"], B = (String)Row["Col3"],Value = Row["Col2"] });
                }
    
                var TableBuild = new DataTable();
                TableBuild.Columns.Add("X");
    
                var DistinctColumnDefiners = List.Select(t => t.B).Distinct();
                var DistinctRowDefiners = List.Select(t => t.A).Distinct();
    
                for (int i = 0; i < DistinctColumnDefiners.Count(); i++)
                {
                    TableBuild.Columns.Add();
                    TableBuild.Columns[i + 1].ColumnName = DistinctColumnDefiners.ToArray()[i];
                }
    
                for (int i = 0; i < DistinctRowDefiners.Count(); i++)
                {
                    TableBuild.Rows.Add();
                    TableBuild.Rows[i]["X"] = DistinctRowDefiners.ToArray()[i];
                }
    
                for (int i = 0; i < DistinctRowDefiners.Count(); i++)
                {
                    for (int k = 0; k < DistinctColumnDefiners.Count(); k++)
                    {
    
                        TableBuild.Rows[i][DistinctColumnDefiners.ToArray()[k]] = List.Where(t => t.A == (String)TableBuild.Rows[i]["X"] && t.B == (String)DistinctColumnDefiners.ToArray()[k]).Select(f=>f.Value).FirstOrDefault();
                    
                    }
                
                }
    
    
                    return TableBuild;
            }
    
    
        }
