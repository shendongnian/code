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
			    return typeof(Calories)
				    .GetProperties()
				    .Where (x => x.PropertyType == typeof(decimal) 
                        && x.Name != "Total")
				    .Sum(p => (decimal)p.GetValue(this));
		    }
  	    }
    }
