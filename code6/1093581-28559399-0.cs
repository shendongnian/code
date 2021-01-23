    public sealed class PaddedString : IUserType,
    								   IEnhancedUserType,
    								   IParameterizedType
    {
    	private int Length { get; set; }
    
    	public void SetParameterValues(IDictionary<string, string> parameters)
    	{
    		this.Length = int.Parse(parameters["length"]);
    	}
    
    	public object NullSafeGet(IDataReader rs,
    							  string[] names,
    							  object owner)
    	{
    		var obj = NHibernateUtil.String.NullSafeGet(rs,
    													names[0]);
    
    		if (obj == null)
    		{
    			return new string(' ',
    							  this.Length);
    		}
    
    		return obj.ToString()
    				  .PadRight(this.Length,
    							' ');
    	}
    }
