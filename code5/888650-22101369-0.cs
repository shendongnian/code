    public class StubRepo : IUserRepository
    {
        public IList<User> PersonList { get; set; }
        public IList<User> FindAll(Func<User, bool> q)
        {
            return PersonList.Where(q).ToList();
        }
    }
