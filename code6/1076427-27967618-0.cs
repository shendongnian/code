    public class CompareUserIDs : IEqualityComparer<UserID>
    {
        public bool Equals(UserID x, UserID y)
        {
            return x.user_id.Equals(y.user_id);
        }
        public int GetHashCode(UserID obj)
        {
            return obj.user_id.GetHashCode();
        }
    }
