    public class DefaultCurrentContext : ICurrentContext
    {
        public User CurrentUser { get; set; }
        public int? CurrentUserId { get { return User != null ? CurrentUser.Id : (int?)null; } }
    }
