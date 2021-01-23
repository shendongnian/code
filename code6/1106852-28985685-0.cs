    //Unit of works acts like a wrapper around DbContext
    //Current unit of work is stored in the HttpContext
    //HttpContext.Current calls are kept in one place, insted of calling it many times
    public class UnitOfWork : IDisposable
    {
        private const string _httpContextKey = "_unitOfWork";
        private MyContext _dbContext;
    
        public static UnitOfWork Current
        {
            get { return (UnitOfWork) HttpContext.Current.Items[_httpContextKey]; }
        }
    
        public UnitOfWork()
        {
            HttpContext.Current.Items[_httpContextKey] = this;
        }
    
        public MyEntities GetContext()
        {
            if(_dbContext == null)
                _dbContext = new MyEntities();
    
            return _dbContext;
        }
    
        public int Commit()
        {
            return _dbContext != null ? _dbContext.SaveChanges() : null;
        }
    
        public void Dispose()
        {
            if(_dbContext != null)
                _dbContext.Dispose();
        }
    }
    
    //ContextManager allows repositories to get an instance of DbContext
    //This implementation grabs the instance from the current UnitOfWork
    //If you want to look for it anywhere else you could write another implementation of IContextManager
    public class ContextManager : IContextManager
    {
        public MyEntities GetContext()
        {
            return UnitOfWork.Current.GetContext();
        }
    }
    
    //Repository provides CRUD operations with different entities
    public class RepositoryBase
    {
        //Repository asks the ContextManager for the context, does not create it itself
        protected readonly IContextManager _contextManager;
    
        public RepositoryBase()
        {
            _contextManager = new ContextManager(); //You could also use DI/ServiceLocator here
        }
    }
    
    //UsersRepository incapsulates Db operations related to User
    public class UsersRepository : RepositoryBase
    {
        public User Get(Guid id)
        {
            return _contextManager.GetContext().Users.Find(id);
        }
    
        //Repository just adds/updates/deletes entities, saving changes is not it's business
        public void Update(User user)
        {
            var ctx = _contextManager.GetContext();
            ctx.Users.Attach(user);
            ctx.Entry(user).State = EntityState.Modified;
        }
    }
    
    public class ItemsRepository : RepositoryBase
    {
        public void UpdateSomeProperties(Item item)
        {
            var ctx = _contextManager.GetContext();
            ctx.Items.Attach(item);
    
            var entry = ctx.Entry(item);
            item.ModifiedDate = DateTime.Now;
    
            //Updating property1 and property2
            entry.Property(i => i.Property1).Modified = true;
            entry.Property(i => i.Property2).Modified = true;
            entry.Property(i => i.ModifiedDate).Modified = true;
        }
    }
    
    //Service encapsultes repositories that are necessary for request handling
    //Its responsibility is to create and commit the entire UnitOfWork
    public class AVeryCoolService
    {
        private UsersRepository _usersRepository = new UsersRepository();
        private ItemsRepository _itemsRepository = new ItemsRepository();
    
        public int UpdateUserAndItem(User user, Item item)
        {
            using(var unitOfWork = new UnitOfWork()) //Here UnitOfWork.Current will be assigned
            {
                _usersRepository.Update(user);
                _itemsRepository.Update(user); //Item object will be updated with the same DbContext instance!
    
    	    //Disposing UnitOfWork: DbContext gets disposed immediately after it is not longer used.
                //Both User and Item updates will be saved in ome transaction
            }
        }
    }
    
    //And finally, the Page
    public class AVeryCoolPage : System.Web.UI.Page
    {
        private AVeryCoolService _coolService;
    
        protected void Btn_Click(object sender, EventArgs e)
        {
            var user = .... //somehow get User and Item objects, for example from control's values
            var item = ....
    
            _coolService.UpdateUserAndItem(user, item);
        }
    }
