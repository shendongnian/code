    public class myModelClass
    {
        private string _mydate;
    	public string mydate
        {
        	get {
        	    return string.Format("{0}/{1}/{2}", _mydate.Substring(0,2),
        	                             _mydate.Substring(2,2),
        				                 _mydate.Substring(4)); }
        	set { _mydate = value; }
        }
    
    }
