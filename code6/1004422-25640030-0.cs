    public interface IRepository<TModel>
    {
        IEnumerable<TModel> Retrieve();
    
        void Create(TModel model);
        void Delete(TModel model);
        void Update(TModel model);
    }
    
    public class RoleRepository : IRepository<Role>
    {
        IEnumerable<TModel> Retrieve()
        {
            using (var context = new MyContext())
            {
    
                return context.Roles.ToList(); // iterating through them hits the database
            }
        }
    
        public void Create(TModel model)
        {
            using (var context = new MyContext())
            {
                context.Set<TModel>().Attach(model);
                context.SaveChanges();
            }
        }
        public void Delete(TModel model) {}
        public void Update(TModel model) {}
    }
    
    public class MyController : Controller
    {
        private readonly IRepository<Role> roleRepository;
    
        public MyController(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }
    }
