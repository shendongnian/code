    public class OrderRequestRepository : IOrderRequestRepository
    {
        private readonly IntranetApplicationsContext _context;
        private readonly ILogger _logger;
        public OrderRequestRepository(IOrderRequestRepositoryFactory respositoryFactory)
        {
            _context = respositoryFactory.CreateIntranetApplicationsContext();
            _logger = respositoryFactory.CreateLogger();
        }
		
		...
    }
   
