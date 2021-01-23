    public interface IRepository<T> where T : class { }
    public class A { }
    public class B { }
    public class RepositoryA : IRepository<A> { }
    public class RepositoryB : IRepository<B> { }
    SimpleIoc.Default.Register<IRepository<A>, RepositoryA>();
    SimpleIoc.Default.Register<IRepository<B>, RepositoryB>();
