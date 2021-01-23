    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        
        public TicketsController(ITicketRepository ticketRepository) 
        {
            _ticketRepository = ticketRepository;
        }
        public ViewResult Index()
        {
            return View(_ticketRepository.FindAll());
        }
        ...
