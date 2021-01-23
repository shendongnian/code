    public interface IBaseInterface
    {
    	string MethodOverloadTest();
    	string MethodOverloadTest(object withParam);
    }
    
    public interface IInterfaceWithNewMethod : IBaseInterface
    {
    	new string MethodOverloadTest();
    }
