    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return (x.Name == y.Name);
        }
        public int GetHashCode(User user)
        {
            return user.GetHashCode();
        }
    }
    context.Orders.Select(o => o.User).Distinct(new UserComparer());
