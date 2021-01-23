    public class ExplorerViewModel
    {
        public static object GetContracts(Project project)
        {
            using (var myDbContext = new SomeDbContext())
            {
                ...
                return result;
            }
        }
    }
