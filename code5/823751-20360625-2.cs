    namespace EFCacheLazyLoadDemo
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity;
        using System.Linq;
        class Program
        {
            static void Main(string[] args)
            {
                // Add some demo data.
                using (MyContext c = new MyContext())
                {
                    var sampleData = new Master 
                    { 
                        Details = 
                        { 
                            new Detail { SomeDetail = "Cod" },
                            new Detail { SomeDetail = "Haddock" },
                            new Detail { SomeDetail = "Perch" }
                        } 
                    };
                    c.Masters.Add(sampleData);
                    c.SaveChanges();
                }
                Master cachedMaster;
                using (MyContext c = new MyContext())
                {
                    c.Configuration.LazyLoadingEnabled = false;
                    c.Configuration.ProxyCreationEnabled = false;
                    // We don't load the details here.  And we don't even need a proxy either.
                    cachedMaster = c.Masters.First();
                }
                Console.WriteLine("Reference entity details count: {0}.", cachedMaster.Details.Count);
                using (MyContext c = new MyContext())
                {
                    var liveMaster = cachedMaster.DeepCopy(c);
                    c.Masters.Attach(liveMaster);
                    Console.WriteLine("Re-attached entity details count: {0}.", liveMaster.Details.Count);
                }
                Console.ReadKey();
            }
        }
        public static class MasterExtensions
        {
            public static Master DeepCopy(this Master source, MyContext context)
            {
                var copy = context.Masters.Create();
                copy.MasterId = source.MasterId;
                foreach (var d in source.Details)
                {
                    var copyDetail = context.Details.Create();
                    copyDetail.DetailId = d.DetailId;
                    copyDetail.MasterId = d.MasterId;
                    copyDetail.Master = copy;
                    copyDetail.SomeDetail = d.SomeDetail;
                }
                return copy;
            }
        }
        public class MyContext : DbContext
        {
            static MyContext()
            {
                // Just for demo purposes, re-create db each time this runs.
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
            }
            public DbSet<Master> Masters { get { return this.Set<Master>(); } }
            public DbSet<Detail> Details { get { return this.Set<Detail>(); } }
        }
        public class Master
        {
            public Master()
            {
                this.Details = new List<Detail>();
            }
            public int MasterId { get; set; }
            public virtual List<Detail> Details { get; private set; }
        }
        public class Detail
        {
            public int DetailId { get; set; }
            public string SomeDetail { get; set; }
            public int MasterId { get; set; }
            [ForeignKey("MasterId")]
            public Master Master { get; set; }
        }
    }
