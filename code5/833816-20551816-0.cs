    public class SomeService
    {
        private DbContext _context;
   
        public SomeService ( DbContext ctx )
        {
            this._context = ctx;
            ...
        }
       // now, context is available for all methods inside the class
