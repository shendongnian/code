    public abstract class TypeA // superclass
    { 
        public abstract void AbtractMethod(IDependency dependency);
    }
    
    public class TypeB : TypeA // subclass 1
    {
        public override void AbtractMethod(IDependency dependency) 
        {
            Contract.Requires(dependency is ISpecializedDependencyForB);
            // ...
        } 
    }
    public class TypeC : TypeA // subclass 2
    {
        public override void AbtractMethod(IDependency dependency)
        {
            Contract.Requires(dependency is ISpecializedDependencyForC)
            // ...
        } 
    }
