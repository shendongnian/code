    public interface IDependentObjectFactory
    {
       IDependentObject GetDependenObject(int clientID);
    }
    
    public class DependentObjectFactory: IDependentObjectFactory
    {
        readonly _kernel kernel;
        public DependentObjectFactory(IKernel kernel)
        {
            _kernel=kernel;
        }
    
        public IDependentObject GetDependenObject(int clientID)
        {
              //use whatever logic here to decide what specific IDependentObject you need to use.
              if (clientID==100)
              {
                  return _kernel.Get<ISpecialDependantObject>(
                         new ConstructorArgument("clientID", clientID));
              }
              else
              {
                 return _kernel.Get<INormalDependentObject>(
                         new ConstructorArgument("clientID", clientID));
              }
        }    
    }
