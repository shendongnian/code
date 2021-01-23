    public interface IDependency
    {
         void DoSomethingPublic();
    }
    internal interface IInternalDependency : IDependency
    {
        void DoSomethingInternal();
    }
    public class YourClass: IInternalDependency
    {
       public void DoSomethingPublic() 
       {
       }
   
       // Note the Explicit interface member implementation
       void IInternalDependency.DoSomethingInternal()
       {
       }
    }
