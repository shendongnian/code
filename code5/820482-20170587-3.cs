    using DSF.Data.Api;
    //using DSF.Data.Repositories; // this makes access to implementation too easy
    
    namespace MvcProj.Controllers
    {
        public class NewCategoriesController
        {
            public NewCategoriesController(INewCategoryRepository repos) { ... }
        }
    }
