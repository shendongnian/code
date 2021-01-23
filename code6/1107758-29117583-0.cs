    public class CODES
    {
    	public string CODE { get; set; }
    	public byte CODE_LEVEL { get; set; }
    	[ ... ]
    
    	public virtual AGGREGATION_CHILDS AggregationChild { get; set; }
    	public virtual AGGREGATIONS Aggregation { get; set; }
    }
    public class AGGREGATIONS
    {
    	public string CODE { get; set; }
    	public string CREATED { get; set; }
    
    	public virtual ICollection<AGGREGATION_CHILDS> AggregationChilds { get; set; }
    	public virtual CODES Code { get; set; }
    }
    public class AGGREGATION_CHILDS
    {
    	public string CODE { get; set; }
    	public string PARENT_CODE { get; set; }
    	public int POSITION { get; set; }
    
    	public AGGREGATIONS Aggregation { get; set; }
    	public CODES Code { get; set; }
    }
