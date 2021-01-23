    public class IdentityGroup<TKey, TGroupRole> : IGroup<TKey>
        where TGroupRole : IdentityGroupRole<TKey>
    {
        public IdentityGroup()
        {
            Roles = new List<TGroupRole>();
        }
        public TKey Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TGroupRole> Roles { get; private set; }
    }
