     public class NameContext:DbContext   
     {
     public NameContext():base(nameOrConnectionString:"maconnexion"){}
        public DbSet<Class1> Class1s{ get; set; }
        public DbSet<Class2> Class2s{ get; set; }}
