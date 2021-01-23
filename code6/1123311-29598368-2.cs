    public class TableParser
    {
        const StringSplitOptions SplitOpts = StringSplitOptions.None;
        const string HeaderColSep = "||";
        const string RowColSep = "|";
        const string MLColSep = @"\\";
        static readonly string[] AllRowsSplit = { HeaderColSep + Environment.NewLine, RowColSep + Environment.NewLine };
        static readonly string[] HeaderColSplit = { HeaderColSep };
        static readonly string[] RowColSplit = { RowColSep };
        static readonly string[] MLColSplit = { MLColSep };
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
            if (!text.EndsWith(Environment.NewLine)) 
                text += Environment.NewLine; // because we need "|" + endline
            var allRows = text.Split(AllRowsSplit, SplitOpts);
            var header  = allRows[0].Split(HeaderColSplit, SplitOpts).Skip(1).Select(f => f.Trim());
            var rows    = allRows.Skip(1).Select(r => 
                new TableRow() { 
                    Cells = r.Split(RowColSplit, SplitOpts)
                        .Skip(1)
                        .Select(c => { 
                            var parts = c.Split(MLColSplit, SplitOpts);
                            var nParts = parts.Length > 1 ? parts.Length - 1 : parts.Length;
                            return parts.Take(nParts)).Select(cv => cv.Trim()).ToArray();
                        }).ToList()
                });
            return new Table() { Header = header.ToArray(), Rows = rows.ToArray() };
        }
    }
