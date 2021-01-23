    public abstract class EntityController<TDbContext> : Controller
       where TDbContext: DbContext
    {
        protected TDbContext DB { get; private set;}
        public EntityController(){
            DB = Activator.CreateInstance<TDbContext>();
        }
        protected override void OnDispose(){
            DB.Dispose();
        }
    }
