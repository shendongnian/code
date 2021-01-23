    public class UserRights
    {
        public virtual LookupNameByID(string id)
        {
            //does whatever a UserRights does.
        }
    }
    public class UserService
    {
        readonly UserRights _rights;
        public UserService(UserRights rights)
        {
           _rights=rights; //null guard omitted for brevity
        }
    
        public string GetName(string id)
        {
           return _rights.LookupNameByID(id);
        }
    }
