    using System;
    using System.Data.Entity;
    namespace EFTPT6
    {
        public class Record
        {
            public virtual int Ndx { get; set; }
            public virtual DateTime CreatedAt { get; set; }
        }
        public class Patient : Record
        {
            public virtual int RecordNdx { get; set; }
            public virtual string Name { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<Record> Records { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Record>()
                    .ToTable("Records");
                modelBuilder.Entity<Record>()
                    .HasKey(r => r.Ndx);
                modelBuilder.Entity<Record>()
                    .Property(r => r.Ndx)
                    .HasColumnName("ndx");
                modelBuilder.Entity<Record>()
                    .Property(r => r.CreatedAt)
                    .HasColumnName("created");
                modelBuilder.Entity<Patient>()
                    .ToTable("Patients");
                modelBuilder.Entity<Patient>()
                    .Property(r => r.Ndx)
                    .HasColumnName("record_ndx");
                modelBuilder.Entity<Patient>()
                    .Ignore(p => p.RecordNdx);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
                using (var ctx = new MyContext())
                {
                    ctx.Database.Initialize(true);
                    string sql = ctx.Records.ToString();
                }
            }
        }
    }
