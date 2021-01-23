    public class PermissionMap : ClassMap<Permission>
    {
        public PermissionMap()
        {
            Table("PERMISSION");
            Id(x => x.Id).Column("PERMISSION_ID");
            Map(x => x.Name);
            HasMany(x => x.UserPermissions).LazyLoad();  // Removed this line to fix issue
        }
    }
