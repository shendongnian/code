    public class UserRepository : ILoginRepository
    {
        CMS3Context _db;
        public UserRepository( CMS3Context db )
        {
            this._db = db;
        }
        ...
    }
