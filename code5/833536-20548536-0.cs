    public interface IUnitOfWork : IDisposable
    {
        ISectionRepository SectionRepository {get;}
        //etc
        int Save();
    }
