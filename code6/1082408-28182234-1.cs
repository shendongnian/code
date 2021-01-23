    public class TicketController {
        private MovieDBContext db = new MovieDBContext ();
    
        public ActionResult Index(int movieId) {
           var listOfTickets = db.Tickets.Where(t=>t.MovieId == movieId).ToList();
           var parentMovie = db.Movie.Where(m=>m.Id == movieId).Single();
            ...
        }
    }
