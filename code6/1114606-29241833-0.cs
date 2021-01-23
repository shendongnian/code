    public abstract class TypeA 
    { 
        public abstract void AbtractMethod(IDependency dependency);
    }
    
    public class TypeB : TypeA
    {
        public override void AbtractMethod(IDependency dependency) 
        {
            Contract.Requires(dependency is ISpecializedDependencyForB);
            // ...
        } 
    }
    public class TypeC : TypeA
    {
        public override void AbtractMethod(IDependency dependency)
        {
            Contract.Requires(dependency is ISpecializedDependencyForC)
            // ...
        } 
    }
