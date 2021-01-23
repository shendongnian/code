    public class IdentityUserKey : IIdentityUserKey
    {
        public long UserId { get; set; }
        public bool Equals(IIdentityUserKey other)
        {
            return other != null && other.UserId == UserId;
        }
        public override string ToString()
        {
            return UserId.ToString();
        }
    }
