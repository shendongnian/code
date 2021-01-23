    namespace DemoContexts
    {
        using System;
        using System.Collections.Generic;
        using System.Data.Entity;
        using System.Linq;
    
    
        public interface IThing
        {
            int Id { get; set; }
            int Status { get; set; }
        }
    
        public class FirstPersonThing : IThing
        {
            [System.ComponentModel.DataAnnotations.Key]
            public int Id { get; set; }
            public int Status { get; set; }
            public string Foo { get; set; }
        }
    
        public class SecondPersonThing : IThing
        {
            [System.ComponentModel.DataAnnotations.Key]
            public int Id { get; set; }
            public int Status { get; set; }
            public string Bar { get; set; }
        }
    
        public class FirstContext : DbContext
        {
            public FirstContext() : base("FirstContext") { }
            public DbSet<FirstPersonThing> MyThings { get; set; }
            public DbSet<SecondPersonThing> YourThings { get; set; }
        }
    
        public class SecondContext : DbContext
        {
            public SecondContext() : base("SecondContext") { }
            public DbSet<FirstPersonThing> MyThings { get; set; }
            public DbSet<SecondPersonThing> YourThings { get; set; }
        }
    
   
        class Program
        {
            static void Main(string[] args)
            {
                int contextType = 1;
                int thingType = 1;
    
                DbContext db = RunTimeCreatedContext(contextType);
                IQueryable<IThing> collection = RunTimeCreatedCollection(db, thingType);
                
                UpdateRuntimeDeterminedThings(db, collection, 1);
                
                Console.ReadLine();
            }
    
            public static void UpdateRuntimeDeterminedThings(DbContext db, 
                                                   IQueryable<IThing> collection, 
                                                   int formId)
            {
                var querySet = collection.Where(p => p.Id == formId).ToList();
                foreach (var result in querySet)
                {
                    result.Status = 0;
                }
    
                db.SaveChanges();
            }
    
            static DbContext RunTimeCreatedContext(int contextType)
            {
                if (contextType == 0)
                {
                    return new FirstContext();
                }
                else
                {
                    return new SecondContext();
                }
            }
    
            static IQueryable<IThing> RunTimeCreatedCollection(DbContext db, int thingType)
            {
                if (thingType == 0)
                {
                    return db.Set(typeof(FirstPersonThing)) as IQueryable<IThing>;
                }
                else
                {
                    return db.Set<SecondPersonThing>();
                }
            }
        }
    }
