    public class SomeController : Controller
    {
        private readonly classThatReadsFromDb;
    
        public SomeController(IInterfaceForClass classThatReadsFromDb)
        {
            this.classThatReadsFromDb = classThatReadsFromDb;
        }
    
        // Controller methods
    }
