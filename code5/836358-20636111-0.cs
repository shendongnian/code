    public interface IB
    {  
        IEnumerable<IA> SetA { get; set; }
        void MethodB1();
    }
    public class B : IB
    {  
    	private List<A> listA;
    
        public IEnumerable<IA> SetA 
    	{
    		get {return listA;} 
    		set {throw new NotImplementedException();} 
    		// the setter is somewhat inelegant, 
    		// if you do not need the setter 
    		// you should probably leave it out of the interface entirely
    	}
    
        public void MethodB1()
        {
                this.listA = new List<A>()
        }
    }
