    public class DataTools
    {
        private AppContext _context;
        protected AppContext Context => _context ?? (_context = new AppContext());
    }
        
    pubic class YourApp : DataTools
    {
        public void DoLotsOfThings()
        {
            var = Context.SomeTable.Where(s => s.....);
            var stuff = GetSomeThing();
           foreach(){}
        }
        
        Public string GetSomething()
        {
            return Context.AnotherTable.First(s => s....).Value;
        }
    }
