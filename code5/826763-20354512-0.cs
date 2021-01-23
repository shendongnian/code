    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Objects.SqlClient;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    namespace testef {       
        [Table("Movies")]
        public class Movie {
            public Int32 Id { get; set; }
            public String Title { get; set; }
        }
        
        public class TestEFContext : DbContext {            
            public DbSet<Movie> Movies { get; set; }
            public TestEFContext(String cs)
                : base(cs) {
                Database.SetInitializer<TestEFContext>(new DropCreateDatabaseAlways<TestEFContext>());
                
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                base.OnModelCreating(modelBuilder);
            }
        }
        class Program {
            static void Main(string[] args) {
                String cs = @"Data Source=ALIASTVALK;Initial Catalog=TestEF;Integrated Security=True; MultipleActiveResultSets=True";
                using (TestEFContext ctx = new TestEFContext(cs)) {
                    ctx.Movies.Add(new Movie { Title = "avatar"});
                    ctx.SaveChanges();
                }
                using (TestEFContext ctx = new TestEFContext(cs)) {
                    Console.WriteLine(ctx.Movies.Count());
                }
                try {
                    using (TestEFContext ctx = new TestEFContext(cs)) {
                        Movie m = new Movie { Id = 1 };
                        //ctx.Movies.Attach(m);
                        ctx.Movies.Remove(m);
                        ctx.SaveChanges();
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                using (TestEFContext ctx = new TestEFContext(cs)) {
                    Console.WriteLine(ctx.Movies.Count());
                }
                using (TestEFContext ctx = new TestEFContext(cs)) {
                    Movie m = new Movie { Id = 1 };
                    ctx.Movies.Attach(m);
                    ctx.Movies.Remove(m);
                    ctx.SaveChanges();
                }
                using (TestEFContext ctx = new TestEFContext(cs)) {
                    Console.WriteLine(ctx.Movies.Count());
                }
            }
        }
    }
