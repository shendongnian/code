    public abstract class Duck {
    
        private string _DucksParam0;
    	
    	public string DucksParam0 {
    	    get {
                return  _DucksParam0;
    	    }
    	}
    
        // Using protected, this constructor can only be used within the class instance
        // or a within a derived class, also in static methods
        protected Duck() { }
    
        public static DuckT Create<DuckT>(string param0)
            where DuckT : Duck
        {
            // Use the (implicit) parameterless constructor
            DuckT theDuck = (DuckT)Activator.CreateInstance(typeof(DuckT));
    
            // This is now your "real" constructor
            theDuck._DucksParam0 = param0;
    
            return theDuck;
        }
    
    }
    
    public class Donald : Duck {
    }
