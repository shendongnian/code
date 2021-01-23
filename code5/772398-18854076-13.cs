    public abstract class UnitOfWorkFactoryBase
    {
        public abstract UnitOfWorkBase Create();
    }
    public class UnitOfWorkFactory : UnitOfWorkFactoryBase
    {
        public override UnitOfWorkBase Create()
        {
            return new UnitOfWork();
        }
    }
    public class MockUnitOfWorkFactory : UnitOfWorkFactoryBase
    {
        public override UnitOfWorkBase Create()
        {
            return new MockUnitOfWork();
        }
    }
