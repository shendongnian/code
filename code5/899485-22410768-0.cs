    public class User
    {
        public int Id { get; set; }
    }
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(User obj)
        {
            return obj.Id.GetHashCode();
        }
    }
