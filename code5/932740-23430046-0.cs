    public class ControllerBase<TManager, TRepository>
       where TManager : ManagerBase<TRepository>
       where TRepository : RepositoryBase
    /* */
    public class SpecificController : ControllerBase<SpecificManager, SpecificRepository>
