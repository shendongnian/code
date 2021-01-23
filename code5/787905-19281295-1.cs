    public class MyContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }
        public MyContext()
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized +=
                (sender, e) => DateTimeKindAttribute.Apply(e.Entity);
        }
    }
