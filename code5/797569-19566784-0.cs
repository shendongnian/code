    public class User : DynamicModel, IUser
    {
        public User() : base() { }
        public User(object dto)
            : base(dto)
        {
        }
        public Guid InternalId { get; set; }
        public DateTime Created { get; set; }
        public bool IsBlocked { get; set; }
        public static implicit operator idata.User(User u)
        {
            idata.User result = new idata.User();
            u.CopyProperties(result);
            return result;
        }
    }
