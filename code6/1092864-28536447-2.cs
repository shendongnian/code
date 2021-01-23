    public class BasicField
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class BasicRow
    {
        public BasicField[] Fields { get; set; }
    }
    public class BasicTable
    {
        public BasicRow[] Rows { get; set; }
        public static BasicTable Parse(DataTable table)
        {
            string[] fieldNames = table.Columns.OfType<DataColumn>().ToList().ConvertAll(c => c.Caption).ToArray();
            List<BasicRow> basicRows = table.Rows.OfType<DataRow>().ToList().ConvertAll(dataRow =>
            {
                List<BasicField> fields = new List<BasicField>();
                for (int i = 0; i < dataRow.ItemArray.Length; i++)
                    fields.Add(new BasicField
                    {
                        Name = fieldNames[i], 
                        Value = dataRow.ItemArray[i]
                    });
                return new BasicRow
                {
                    Fields = fields.ToArray()
                };
            });
            return new BasicTable
            {
                Rows = basicRows.ToArray()
            };
        }
    }
