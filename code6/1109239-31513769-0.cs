    public class AdminMappings : ClassMap<Admins>
    {
        public AdminMappings()
        {
            CompositeId().KeyReference(x => x.User, "UserId");
        }
    }
