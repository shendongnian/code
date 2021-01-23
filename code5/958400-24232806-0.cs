     public class CustomReader : DbDataReader
    {
        private readonly SqlDataReader sqlDataReader;
        //Set the sqlDataReader
        public CustomReader(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader;
            //Cache the names
            this.CacheColumns();
        }
        private Dictionary<string,int> nameOrdinals = new Dictionary<string, int>(); 
        private void CacheColumns()
        {
            int fieldCount= this.sqlDataReader.FieldCount;
            for (int i = 0; i <= fieldCount-1; i++)
            {
                string name=sqlDataReader.GetName(i);
                nameOrdinals.Add(name,i);
            }
        }
        public override object this[string name]
        {
            get
            {
                int ordinal=this.nameOrdinals[name];
                return this.GetValue(ordinal);
            }
        }
        //Custom implementation
        public string GetString(string name)
        {
            int ordinal = this.nameOrdinals[name];
            return this.GetString(ordinal);
        }
        //Custom implementation
        public string GetString(string name,string defaultValue)
        {
            int ordinal = this.nameOrdinals[name];
            if (this.IsDBNull(ordinal))
            {
                return defaultValue;
            }
            return this.GetString(ordinal);
        }
        //return from sqlDataReader
        public override string GetString(int ordinal)
        {
            return sqlDataReader.GetString(ordinal);
        }
        public override void Close()
        {
            sqlDataReader.Close();
        }
