    using DSF.Data.Api;
    //using DSF.Data.Repositories; // don't make access to implementation easy
    
    namespace MvcProj.Controllers
    {
        public class NewCategoriesController
        {
            public NewCategoriesController(INewCategoryRepository repos) { ... }
        }
    }
