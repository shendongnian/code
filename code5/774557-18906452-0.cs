    public class TicketsController : Controller
    {
        private readonly ITicketDBContext _dbContext;
        
        public TicketsController(ITicketDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        ...
