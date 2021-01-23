    public class Employee {
    	#region Constructor(s)
    	
    	public Employee() {
    		HomeAddress = new Address();
    	}
    	
    	#endregion
    	#region Properties
    
        public string Name { get; set;}
    	public IAddress HomeAddress { get; private set; }
    	
    	#endregion
    	#region Nested
    	
    	public interface IAddress {
    		string Street { get; set; }
    	}
        private class Address: IAddress {
            public string Street { get; set;}
        }
    	
    	#endregion
    }
