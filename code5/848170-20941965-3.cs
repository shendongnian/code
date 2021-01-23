    public class UserManager
    {
        public void Register(string userName, string email)
        {
            //TODO: Register in DB.
            UserCache.Current.Add(new User
            {
                UserID = Guid.NewGuid(),
                Email = email,
                UserName = userName
            });
        }
    }
