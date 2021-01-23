    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    namespace SQLite
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var conn = new SQLiteConnection(@"C:\linqToSqlite.db"))
                {
                    SeedEntities(conn);
    
                    // this is the query that DID work for you
                    var result1 = conn.Kursy
                        .Where(k => k.id_kursy == 1)
                        .FirstOrDefault();
    
                    Console.WriteLine(
                        string.Format("id_kursy:{0}", result1.id_kursy));
    
                    // this is the query that did NOT work for you
                    // it does work here
                    var result2 = conn.Kursy
                        .Where(k => k.kantory.id_kantory == 1)
                        .FirstOrDefault();
    
                    Console.WriteLine(
                        string.Format("id_kursy:{0}", result2.id_kantory));
                }
    
                Console.ReadKey();
            }
    
            private static void SeedEntities(SQLiteConnection conn)
            {
                SeedEntities(conn);
                // make sure two entities exist with the appropriate ids
                if (!conn.Kantory.Any(x => x.id_kantory == 1))
                {
                    conn.Kantory
                        .Add(new Kantory() { id_kantory = 1 });
                }
    
                if (!conn.Kursy.Any(x => x.id_kantory == 1))
                {
                    conn.Kursy
                        .Add(new Kursy() { id_kantory = 1 });
                }
    
                conn.SaveChanges();
            }        
        }
    
        public class SQLiteConnection : DbContext
        {
            public SQLiteConnection(string connString) : 
                base(connString) {}
            public DbSet<Kantory> Kantory { get; set; }
            public DbSet<Kursy> Kursy { get; set; }
        }
    
        public class Kantory
        {
            public Kantory()
            {
                this.kursy = new HashSet<Kursy>();
            }
    
            [Key]
            public int id_kantory { get; set; }
            public virtual ICollection<Kursy> kursy { get; set; }
        }
    
        public class Kursy
        {
            [Key]
            public int id_kursy { get; set; }
            public int id_kantory { get; set; }
            public virtual Kantory kantory { get; set; }
        }
    }
