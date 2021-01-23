    using System;
    using System.Data.Entity;
    using System.Linq;
    public class MyEntity
    {
        public int Id { get; set; }
        public string MyString { get; set; }
    }
    public class MyContext : DbContext
    {
        static MyContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
        }
        public DbSet<MyEntity> MyEntities
        {
            get { return this.Set<MyEntity>(); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                context.Database.Log = Console.Write;
                context.MyEntities.Add(new MyEntity { MyString = "Fish" });
                context.MyEntities.Add(new MyEntity { MyString = "Fish" });
                context.MyEntities.Add(new MyEntity { MyString = "Haddock" });
                context.MyEntities.Add(new MyEntity { MyString = "Perch" });
                context.SaveChanges();
                Console.WriteLine("{0} distinct values.", context.MyEntities.Select(q => q.MyString).Distinct().Count());
                Console.ReadKey();
            }
        }
    }
