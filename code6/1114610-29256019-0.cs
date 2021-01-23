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
                   return SpecializedDependencyForB.CreateSpecializedDependencyForB(); 
              } 
        }
        public override void AbtractMethod() { }
    }
    
    public static class SpecializedDependencyForB
    {
    	public static ISpecializedDependencyForB DependencyForB
    	{
    		return CreateSpecializedDependencyForB();
    	}
    	public delegate ISpecializedDependencyForB CreateSpecializedDependencyForBDelegate();
    	public static CreateSpecializedDependencyForBDelegate CreateSpecializedDependencyForB;
    }
