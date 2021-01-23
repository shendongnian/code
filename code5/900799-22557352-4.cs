    public abstract class User
    {
        public virtual int Id { get; protected set; }
        public virtual IEnumerable<AccessPermission> AccessPermissions { get; protected set; }
    }
