    public interface IRepositoryEntity
    {
       object Id { get; }
    }
    public interface IManagedRepositoryEntity : IRepositoryEntity
    {
        new object Id { get; set; }
    }
