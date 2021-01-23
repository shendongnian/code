    public static class IdentityExtensions
    {
        public static Guid GetGuidUserId(this IIdentity identity)
        {
            Guid result = Guid.Empty;
            Guid.TryParse(identity.GetUserId(), out result);
            return result;
        }   
    }
