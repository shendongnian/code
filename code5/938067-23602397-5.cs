        private DataTable GetDataTable(string fileName)
        {
            var table = new DataTable();
            var lines = File.ReadAllLines(@"C:\temp\1.txt");
            if (lines.Count() > 0)
            {
                foreach (var columnName in lines.FirstOrDefault()
                    .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    table.Columns.Add(columnName);
                }
                foreach (var cellValues in lines.Skip(1))
                {
                    var cellArray = cellValues
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (cellArray.Length == table.Columns.Count)
                        table.Rows.Add(cellArray);
                }
            }
            return table;
        }
    
