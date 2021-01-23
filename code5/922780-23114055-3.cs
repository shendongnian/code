    public class CustomDataReader : IDataReader
    {
        private List<Mapping> mappings  = null;
        private string[] database_columns; 
        private int _currentIndex = -1;
        private System.Data.DataTable csv_data;
        public CustomDataReader(
            List<Mapping> _mappings, 
            string[] _database_columns, 
            System.Data.DataTable _csv_data, 
            bool skip_first_row)
        {
            mappings = _mappings;
            database_columns = _database_columns;
            csv_data = _csv_data;
            if (skip_first_row)
                _currentIndex++;
        }
        // get the number of data fields in each record.
        public int FieldCount
        {
            get { return database_columns.Count(); } 
        }
        public bool Read()
        {
            if ((_currentIndex + 1) < csv_data.Rows.Count)
            {
                _currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }
        // get the column name for the specified db column number.  
        public string GetName(int i)
        {
            if(i > 0 && i < database_columns.Count())
            {
                return database_columns[i];
            }
            return string.Empty;
        }
        // get the column number for the specified dbcolumn name.
        public int GetOrdinal(string name)
        {
            for (int i = 0; i < database_columns.Count(); i++)
            {
                if (database_columns[i] == name)
                    return i;
            }
            return -1;
        }
        // get the value of the field for the supplied column number. 
        public object GetValue(int i)
        {            
            // loop through our mappings
            foreach (Mapping p in mappings)
            {
                // find the mapping that relates to this db column
                if(p.db_column_index == i)
                {
                    // if column format is specified, build the data
                    if (p.column_format != null)
                    {
                        List<string> data = new List<string>();
                        foreach (int b in p.csv_cols)
                        {
                            data.Add(csv_data.Rows[_currentIndex][b].ToString());
                        }
                        return string.Format(p.column_format, data.ToArray());
                    }
                    // otherwise, just return the value we need
                    else
                        return csv_data.Rows[_currentIndex][p.csv_cols[0]];
                }
            }
            return null;
        }
        #region Not Implemented
        public void Close()
        {
            throw new NotImplementedException();
        }
        public int Depth
        {
            get { throw new NotImplementedException(); }
        }
        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }
        public bool IsClosed
        {
            get { throw new NotImplementedException(); }
        }
        public bool NextResult()
        {
            throw new NotImplementedException();
        }
        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }
        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }
        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }
        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }
        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }
        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }
        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }
        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }
        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }
        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }
        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }
        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }
        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }
        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }
        public string GetString(int i)
        {
            throw new NotImplementedException();
        }
        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }
        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }
        public object this[string name]
        {
            get { throw new NotImplementedException(); }
        }
        public object this[int i]
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
