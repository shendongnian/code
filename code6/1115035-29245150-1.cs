        public static IEnumerable<XElement> GetRowsWithColumn(IEnumerable<XElement> rows, String name, String value) 
        {
            return rows
                .Where(row => row.Elements("col")
                    .Any(col =>
                        col.Attributes("name").Any(attr => attr.Value.Equals(name))
                        && col.Value.Equals(value)));
        }
