    public interface IBaseInterface
    {
    	string BaseMethodTokeep();
    
        string MethodToHide();
    	string MethodSameName();
    }
    
    public interface IInterfaceWithNewMethod : IBaseInterface
    {
        new string MethodToHide();
    	new string MethodSameName(object butDifferentParameters);
    	
    	string DerivedMethodToKeep();
    }
