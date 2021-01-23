    public interface ISoftDeletable
    {
    }
    public interface IPermanentDeleteable
    {
    }
    public interface IRepository<TEntity>
    {
    }
    public class PermanentDeletableRepository<TEntity> : IRepository<TEntity>
        where TEntity : IPermanentDeleteable
    {
    }
    public class SoftDeletableRepository<TEntity> : IRepository<TEntity>
        where TEntity : ISoftDeletable
    {
    }
    public override void Load()
    {
        this.Bind(typeof(IRepository<>))
            .To(typeof(PermanentDeletableRepository<>))
            .When(IsRequestForRepositoryOfEntityImplementing<IPermanentDeleteable>);
        this.Bind(typeof(IRepository<>))
            .To(typeof(SoftDeletableRepository<>))
            .When(IsRequestForRepositoryOfEntityImplementing<ISoftDeletable>);
    }
    public static bool IsRequestForRepositoryOfEntityImplementing<TInterface>(IRequest request)
    {
        Type entityType = GetEntityTypeOfRepository(request.Service);
        return ImplementsInterface<TInterface>(entityType);
    }
    public static Type GetEntityTypeOfRepository(Type repositoryType)
    {
        // target.Type must be IRepository<"AnyEntity">
        return repositoryType.GetGenericArguments().Single();
    }
    public static bool ImplementsInterface<TInterface>(Type type)
    {
        return typeof(TInterface).IsAssignableFrom(type);
    }
