    public interface IMyEntityRepository : IRepository<MyEntity>
    {
      // ...
    }
    public class MyEntityRepository : Repository<MyEntity>, IMyEntityRepository
    {
      // ...
    }
