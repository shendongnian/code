    public abstract class TypeA 
    { 
        public abstract void AbtractMethod();
    }
    
    public class TypeB : TypeA
    {
    	private ISpecializedDependencyForB SpecializedDependencyForB 
         { 
              get 
              { 
                   return GetSpecializedDependencyForB.CreateSpecializedDependencyForB(); 
              } 
        }
        public override void AbtractMethod() { // do stuff with dependency }
    }
    
    public static class GetSpecializedDependencyForB
    {
    	public static ISpecializedDependencyForB DependencyForB
    	{
    		return CreateSpecializedDependencyForB();
    	}
    	public delegate ISpecializedDependencyForB CreateSpecializedDependencyForBDelegate();
    	public static CreateSpecializedDependencyForBDelegate CreateSpecializedDependencyForB;
    }
