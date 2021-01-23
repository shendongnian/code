    public class IdentityPermission<TKey, TRolePermission>
    {
        public virtual TKey Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    
        public virtual ICollection<TRolePermission> Roles { get; set; }
    }
