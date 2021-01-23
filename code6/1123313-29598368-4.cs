    public class TableParser
    {
        const StringSplitOptions SplitOpts = StringSplitOptions.None;
        const string RowColSep = "|";
        static readonly string[] HeaderColSplit = { "||" };
        static readonly string[] RowColSplit = { RowColSep };
        static readonly string[] MLColSplit = { @"\\" };
        public class TableRow
        {
            public List<string[]> Cells;
        }
        public class Table
        {
            public string[] Header;
            public TableRow[] Rows;
        }
        public static Table Parse(string text)
        {
            // Isolate the header columns and rows remainder.
            var headerSplit = text.Split(HeaderColSplit, SplitOpts);
            Ensure(headerSplit.Length > 1, "At least 1 header column is required in the input");
            // Need to check whether there are any rows.
            var hasRows = headerSplit.Last().IndexOf(RowColSep) >= 0;
            var header = headerSplit.Skip(1)
                .Take(headerSplit.Length - (hasRows ? 2 : 1))
                .Select(c => c.Trim())
                .ToArray();
            if (!hasRows) // If no rows for this table, we are done.
                return new Table() { Header = header, Rows = new TableRow[0] };
            // Get all row columns from the remainder.
            var rowsCols = headerSplit.Last().Split(RowColSplit, SplitOpts);
            // Require same amount of columns for a row as the header.
            Ensure((rowsCols.Length % (header.Length + 1)) == 1, 
                "The number of row colums does not match the number of header columns");
            var rows = new TableRow[(rowsCols.Length - 1) / (header.Length + 1)];
            // Fill rows by sequentially taking # header column cells 
            for (int ri = 0, start = 1; ri < rows.Length; ri++, start += header.Length + 1)
            {
                rows[ri] = new TableRow() { 
                    Cells = rowsCols.Skip(start).Take(header.Length)
                        .Select(c => c.Split(MLColSplit, SplitOpts).Select(p => p.Trim()).ToArray())
                        .ToList()
                };
            };
            return new Table { Header = header, Rows = rows };
        }
        private static void Ensure(bool check, string errorMsg)
        {
            if (!check)
                throw new InvalidDataException(errorMsg);
        }
    }
