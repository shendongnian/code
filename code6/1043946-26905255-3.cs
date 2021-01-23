      public interface IUserRepository : IRepository<UserModel, int>
        {
            UserModel GetByEmail(string email);
            Task<UserModel> GetByEmail(string email);
         }
     public interface IRepository<TModel, TKey> where TModel : class
        {
        }
