    public interface IOrderRequestRepositoryFactory
    {
        ILogger CreateLogger();
        IntranetApplicationsContext CreateIntranetApplicationsContext();
    }
    public class OrderRequestRepositoryFactory : IOrderRequestRepositoryFactory
    {
        public ILogger CreateLogger()
        {
            return new ElmahLogger();
        }
        public IntranetApplicationsContext CreateIntranetApplicationsContext()
        {
            return new IntranetApplicationsContext();
        }
    }
	
