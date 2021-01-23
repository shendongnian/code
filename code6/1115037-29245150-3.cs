        public static IEnumerable<XElement> GetRowsWithColumn(IEnumerable<XElement> rows, String name, String value) 
        {
            return rows
                .Where(row => row.Elements("col") //Get Columns
                    .Any(col => //This column should...
                        col.Attributes("name").Any(attr => attr.Value.Equals(name)) //have the right name attribute
                        && col.Value.Equals(value))); //and have the right value
        }
