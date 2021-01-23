    public class MyService : IMyService
    {
        private readonly IRepository<Role> roleRepository;
        
        public MyService(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }
    
        public IEnumerable<Role> LetsDoSomeCoolThings()
        {
            // some complicated role specific function to return a complex set of results
        }
    }
