    /// <inheritdoc />
    public class WrappedDataReader
    {
    	private readonly IList<AdditionalField> _additionalFields;
    	private readonly int _originalOrdinalCount;
    	private IDbCommand _cmd;
    	private int _currentRowIndex = -1; //The first Read() will make this 0
    	private IDataReader _underlyingReader;
    
    	public WrappedDataReader(IDataReader underlyingReader, IList<AdditionalField> additionalFields)
    	{
    		_additionalFields = additionalFields;
    		_underlyingReader = underlyingReader;
    
    		var schema = Reader.GetSchemaTable();
    		if (schema == null)
    		{
    			throw new ObjectDisposedException(GetType().Name);
    		}
    
    		_originalOrdinalCount = schema.Rows.Count;
    	}
    
    	public object this[int i]
    	{
    		get { throw new NotImplementedException(); }
    	}
    
    	public IDataReader Reader
    	{
    		get
    		{
    			if (_underlyingReader == null)
    			{
    				throw new ObjectDisposedException(GetType().Name);
    			}
    
    			return _underlyingReader;
    		}
    	}
    
    	IDbCommand IWrappedDataReader.Command
    	{
    		get
    		{
    			if (_cmd == null)
    			{
    				throw new ObjectDisposedException(GetType().Name);
    			}
    
    			return _cmd;
    		}
    	}
    
    	void IDataReader.Close() => _underlyingReader?.Close();
    
    	int IDataReader.Depth => Reader.Depth;
    
    	DataTable IDataReader.GetSchemaTable()
    	{
    		var rv = Reader.GetSchemaTable();
    		if (rv == null)
    		{
    			throw new ObjectDisposedException(GetType().Name);
    		}
    
    		for (var i = 0; i < _additionalFields.Count; i++)
    		{
    			var row = rv.NewRow();
    
    			row["ColumnName"] = _additionalFields[i].ColumnName;
    			row["ColumnOrdinal"] = GetAppendColumnOrdinal(i);
    			row["DataType"] = _additionalFields[i].DataType;
    
    			rv.Rows.Add(row);
    		}
    
    		return rv;
    	}
    
    	bool IDataReader.IsClosed => _underlyingReader?.IsClosed ?? true;
    
    	bool IDataReader.NextResult() => Reader.NextResult();
    
    	bool IDataReader.Read()
    	{
    		_currentRowIndex++;
    		return Reader.Read();
    	}
    
    	int IDataReader.RecordsAffected => Reader.RecordsAffected;
    
    	void IDisposable.Dispose()
    	{
    		_underlyingReader?.Close();
    		_underlyingReader?.Dispose();
    		_underlyingReader = null;
    		_cmd?.Dispose();
    		_cmd = null;
    	}
    
    	int IDataRecord.FieldCount => Reader.FieldCount + _additionalFields.Count;
    
    	bool IDataRecord.GetBoolean(int i) => Reader.GetBoolean(i);
    
    	byte IDataRecord.GetByte(int i) => Reader.GetByte(i);
    
    	long IDataRecord.GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) =>
    		Reader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
    
    	char IDataRecord.GetChar(int i) => Reader.GetChar(i);
    
    	long IDataRecord.GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) =>
    		Reader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
    
    	IDataReader IDataRecord.GetData(int i) => Reader.GetData(i);
    
    	string IDataRecord.GetDataTypeName(int i) => Reader.GetDataTypeName(i);
    
    	DateTime IDataRecord.GetDateTime(int i) => Reader.GetDateTime(i);
    
    	decimal IDataRecord.GetDecimal(int i) => Reader.GetDecimal(i);
    
    	double IDataRecord.GetDouble(int i) => Reader.GetDouble(i);
    
    	Type IDataRecord.GetFieldType(int i) => Reader.GetFieldType(i);
    
    	float IDataRecord.GetFloat(int i) => Reader.GetFloat(i);
    
    	Guid IDataRecord.GetGuid(int i) => Reader.GetGuid(i);
    
    	short IDataRecord.GetInt16(int i) => Reader.GetInt16(i);
    
    	int IDataRecord.GetInt32(int i)
    	{
    		return i >= _originalOrdinalCount ? (int) ExecuteAdditionalFieldFunc(i) : Reader.GetInt32(i);
    	}
    
    	long IDataRecord.GetInt64(int i) => Reader.GetInt64(i);
    
    	string IDataRecord.GetName(int i)
    	{
    		return i >= _originalOrdinalCount ? _additionalFields[GetAppendColumnIndex(i)].ColumnName : Reader.GetName(i);
    	}
    
    	int IDataRecord.GetOrdinal(string name)
    	{
    		for (var i = 0; i < _additionalFields.Count; i++)
    		{
    			if (name.Equals(_additionalFields[i].ColumnName, StringComparison.OrdinalIgnoreCase))
    			{
    				return GetAppendColumnOrdinal(i);
    			}
    		}
    
    		return Reader.GetOrdinal(name);
    	}
    
    	string IDataRecord.GetString(int i) => Reader.GetString(i);
    
    	object IDataRecord.GetValue(int i)
    	{
    		return i >= _originalOrdinalCount ? ExecuteAdditionalFieldFunc(i) : Reader.GetValue(i);
    	}
    
    	int IDataRecord.GetValues(object[] values) => Reader.GetValues(values);
    
    	bool IDataRecord.IsDBNull(int i)
    	{
    		return i >= _originalOrdinalCount ? ExecuteAdditionalFieldFunc(i) == null : Reader.IsDBNull(i);
    	}
    
    	object IDataRecord.this[string name]
    	{
    		get
    		{
    			var ordinal = ((IDataRecord) this).GetOrdinal(name);
    			return ((IDataRecord) this).GetValue(ordinal);
    		}
    	}
    
    
    	object IDataRecord.this[int i] => ((IDataRecord) this).GetValue(i);
    
    	private int GetAppendColumnOrdinal(int index)
    	{
    		return _originalOrdinalCount + index;
    	}
    
    	private int GetAppendColumnIndex(int oridinal)
    	{
    		return oridinal - _originalOrdinalCount;
    	}
    
    	private object ExecuteAdditionalFieldFunc(int oridinal)
    	{
    		return _additionalFields[GetAppendColumnIndex(oridinal)].Func(_currentRowIndex, Reader);
    	}
    
    	public struct AdditionalField
    	{
    		public AdditionalField(string columnName, Type dataType, Func<int, IDataReader, object> func = null)
    		{
    			ColumnName = columnName;
    			DataType = dataType;
    			Func = func;
    		}
    
    		public string ColumnName;
    		public Type DataType;
    		public Func<int, IDataReader, object> Func;
    	}
    }
