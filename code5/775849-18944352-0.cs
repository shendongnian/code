    public interface IEntity
    {
        //Implementation
    
    }
    internal interface ITestEntity : IEntity
    {
        void TestMethod();
    }
    class Entity: ITestEntity
    {
       //
    }
