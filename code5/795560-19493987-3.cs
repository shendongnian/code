    public class myModelClass
    {
        private string _MyDate;
    	public string MyDate
        {
        	get {
        	    return string.Format("{0}/{1}/{2}", _MyDate.Substring(0,2),
        	                             _MyDate.Substring(2,2),
        				                 _MyDate.Substring(4)); }
        	set { _MyDate = value; }
        }
    
    }
