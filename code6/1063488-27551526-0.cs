    public class SomeController {
         
         private DataContext _context;
         private SomeService _service;
    
         public SomeController() {
              _context = ...InstantiateContext();
              _service = new SomeService(_context);
         }   
    }
