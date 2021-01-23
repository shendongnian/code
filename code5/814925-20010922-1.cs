    public abstract class GenericController<T, TRepo> 
            where T : class
            where TRepo : IBaseRepository
        {
            private IBaseRepository repository;
    
            public GenericController(IBaseRepository r) 
            {
                repository = ;
            }
    
            public virtual ActionResult Details(int id)
            {
               var model =repository.Get<T>(id);
               return View(model);
            }
        }
