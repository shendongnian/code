    public class IdentityRole<TKey, TRolePermission>
    {
        public string Title { get; set; }
    
        public virtual ICollection<TRolePermission> Permissions { get; set; }
    }
