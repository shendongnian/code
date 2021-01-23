    public class NotificationUser
    {
        public NotificationUser()
        {
            UserGroups = new HashSet<NotificationUserGroup>();
        }
        public int NotificationUserId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<NotificationUserGroup> UserGroups { get; set; }
    }
    public class NotificationUserGroup
    {
        public int NotificationUserGroupId { get; set; }
        public string GroupName { get; set; }
    }
    public class Context : DbContext
    {
        public Context()
            : base()
        {
        }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<NotificationUserGroup> NotificationUserGroup { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            using (var ctx = new Context())
            {
                var user = new NotificationUser() { UserName = "Name1" };
                user.UserGroups.Add(new NotificationUserGroup() { GroupName = "Group1" });
                user.UserGroups.Add(new NotificationUserGroup() { GroupName = "Group2" });
                ctx.NotificationUsers.Add(user);
                ctx.SaveChanges();
            }
            using (var ctx = new Context())
            {
                foreach (var user in ctx.NotificationUsers)
                {
                    foreach (var group in user.UserGroups)
                        Console.WriteLine("Group Id: {0}, Group Name: {1}, UserName: {2}", group.NotificationUserGroupId, group.GroupName,user.UserName);
                }
                foreach (var group in ctx.NotificationUserGroup)
                {
                    Console.WriteLine("Group Id: {0}, Group Name: {1}", group.NotificationUserGroupId, group.GroupName);
                }
            }
            Console.ReadKey();
        }
    }
