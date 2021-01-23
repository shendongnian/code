    namespace Samples
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Text;
    
        public class Sample
        {
            public static void Main()
            {
                DataTable data = GetTable();
                HtmlTable html = new HtmlTable()
                    .BindTable(data)
                    .BindColumn("ID", "Ident", 64)
                    .BindColumn("Name", "First name", 128)
                    .BindColumn("Description", "Things to know", 256);
                Console.WriteLine(html.BuildHtml());
                Console.ReadLine();
            }
    
            private static DataTable GetTable()
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Description", typeof(string));
                table.Columns.Add("Date", typeof(DateTime));            
                table.Rows.Add(1, "Alice", "Likes encryption.", DateTime.Now);
                table.Rows.Add(2, "Bob", "Has to decrypt a lot.", DateTime.Now);
                table.Rows.Add(3, "Charlie", "Not really funny.", DateTime.Now);
                table.Rows.Add(4, "David", "Knows how to use stones.", DateTime.Now);
                table.Rows.Add(5, "Elmer", "Don't mess with him, when wearing bunny ears.", DateTime.Now);
                return table;
            }
        }
    
        public class HtmlTable
        {
            private List<HtmlTableColumn> columns = new List<HtmlTableColumn>();
            private DataTable dataTable= null;
    
            public HtmlTable BindTable(DataTable dataTable)
            {
                this.dataTable = dataTable;
                return this;
            }
    
            public HtmlTable BindColumn(string columnName, string caption, int width)
            {
                this.columns.Add(new HtmlTableColumn() { Caption = caption, ColumnName = columnName, Width = width });
                return this;
            }
    
            public string BuildHtml()
            {
                StringBuilder result = new StringBuilder();
                // Build your HTML table.
                return result.ToString();
            }
        }
    
        public class HtmlTableColumn
        {
            public string Caption { get; set; }
            public string ColumnName { get; set; }
            public int Width { get; set; }
        }
    }
