    public class Calories
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public string TestString { get;set;}
      
    	public decimal Total 
     	{ 
    		get
    		{
    			var accessor = FastMember.TypeAccessor.Create(this.GetType());
    			
    			return accessor.GetMembers()
    				.Where (x => x.Type == typeof(decimal) && x.Name != "Total")
    				.Sum(p => (decimal)accessor[this, p.Name]);
    		}
      	}
    }
