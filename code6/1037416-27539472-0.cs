    public class DelimitedList : IUserType
    {
    	private const string delimiter = "|";
    
    	public new bool Equals(object x, object y)
    	{
    		return object.Equals(x, y);
    	}
    
    	public int GetHashCode(object x)
    	{
    		return x.GetHashCode();
    	}
    
    	public object NullSafeGet(IDataReader rs, string[] names, object owner)
    	{
    		var r = rs[names[0]];
    		return r == DBNull.Value 
    			? new List<string>()
    			: ((string)r).SplitAndTrim(new [] { delimiter });
    	}
    
    	public void NullSafeSet(IDbCommand cmd, object value, int index)
    	{
    		object paramVal = DBNull.Value;
    		if (value != null)
    		{
    			paramVal = ((IEnumerable<string>)value).Join(delimiter);
    		}
    		var parameter = (IDataParameter)cmd.Parameters[index];
    		parameter.Value = paramVal;
    	}
    
    	public object DeepCopy(object value)
    	{
    		return value;
    	}
    
    	public object Replace(object original, object target, object owner)
    	{
    		return original;
    	}
    
    	public object Assemble(object cached, object owner)
    	{
    		return cached;
    	}
    
    	public object Disassemble(object value)
    	{
    		return value;
    	}
    
    	public SqlType[] SqlTypes
    	{
    		get { return new SqlType[] { new StringSqlType() }; }
    	}
    
    	public Type ReturnedType
    	{
    		get { return typeof(IList<string>); }
    	}
    
    	public bool IsMutable
    	{
    		get { return false; }
    	}
    }
