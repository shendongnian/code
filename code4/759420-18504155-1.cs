    public class WrapperDataReader : IDataReader
    {
        private IDataReader reader;
        public WrapperDataReader(IDataReader reader)
        {
            this.reader = reader;
        }
        public void Close()
        {
            reader.Close();
        }
        public int Depth
        {
            get { return reader.Depth; }
        }
        public DataTable GetSchemaTable()
        {
            var schemaTable = reader.GetSchemaTable();
            // add your computed column to the schema table
            schemaTable.Rows.Add(...);
            return schemaTable;
        }
        public bool GetBoolean(int i)
        {
            return reader.GetBoolean(i);
        }
        public int GetOrdinal(string name)
        {
            if (name.Equals("displayName", StringComparison.InvariantCultureIgnoreCase))
                return 15;
            return reader.GetOrdinal(name);
        }
        public string GetString(int i)
        {
            if (i == 15)
                return String.Format("{0}, {1}", GetString(1), GetString(2)); // lastname, firstname
            return reader.GetString(i);
        }
    }
