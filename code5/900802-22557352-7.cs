    public class AccessPermissionMap : ClassMap<AccessPermission>
    {
        public AccessPermissionMap()
        {
            this.Id(x => x.Id);
            this.References(x => x.Object);
            this.References(x => x.Subject);
        }
    }
