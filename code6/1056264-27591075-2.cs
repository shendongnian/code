    public class ExplorerViewModel
    {
        private static SomeDbContext _myDbContext = new SomeDbContext();
    
        public static object GetContracts(Project project)
        {
            _myDbContext.DoSomething();
            ...
            return result;
        }
    }
