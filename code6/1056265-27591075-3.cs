    public class ExplorerViewModel
    {
        public static object GetContracts(Project project)
        {
            using (var myDbContext = new SomeDbContext())
            {
                myDbContext.DoSomething();
                ...
                return result;
            }
        }
    }
