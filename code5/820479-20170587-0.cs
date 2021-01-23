    namespace DSF.Data.Api
    {
        public interface INewCategoryRepository
        {
            IList<NewsCategory> GetAll();
        }
    }
    namespace DSF.Data.Repositories
    {
        using DSF.Data.Api;
        public class NewCategoryRepository : RepositoryBase,INewCategoryRepository
        {
            public IList<NewsCategory> GetAll()
            {
                return _db.NewsCategory.ToList();
            }
    
        }
    }
