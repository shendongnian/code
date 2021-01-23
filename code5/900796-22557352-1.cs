    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            this.Id(x => x.Id);
            this.HasMany(x => x.AccessPermissions);
            this.DiscriminateSubClassesOnColumn("Type");
        }
    }
