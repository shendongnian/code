    public class Context : DbContext    
    {
        public Context() : base("MyDb") { }
        public DbSet<A> As { get; set; }        
        public DbSet<C> Cs { get; set; }
        public DbSet<D> Ds { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<C>().HasKey(a => a.Id);
            modelBuilder.Entity<C>().HasKey(a => a.Id).HasOptional(a => a.A)
                .WithMany(b => b.Cs).HasForeignKey(c => c.AId);
            modelBuilder.Entity<D>().HasKey(a => a.Id).HasOptional(a => a.A)
                .WithMany(b => b.Ds).HasForeignKey(c => c.AId);
        }    
    }    
    public class A {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<C> Cs { get; set; }
        public virtual ICollection<D> Ds { get; set; }
    }                
    public class C {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual A A { get; set; }        
        public int? AId { get; set; }
    }
    public class D {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual A A { get; set; }        
        public int? AId { get; set; }
    }
