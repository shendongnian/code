    namespace MyProject.Data
    {
    	public class AGGREGATION_CHILDS
    	{
    		public string CHILD_CODE { get; set; }
    		public string PARENT_CODE { get; set; }
    		public int POSITION { get; set; }
    
    		public virtual AGGREGATIONS Aggregation { get; set; }
    		public virtual CODES Code { get; set; }
    	}
    }
