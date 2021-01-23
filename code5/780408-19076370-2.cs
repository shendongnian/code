    public class Moo : Controller
    {
        Custom c;
    
        public Moo()
        {
            c = new Custom();
        }
    
        // Use c throughout this class    
    
        protected override Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
               c.Dispose()
        }
    }
