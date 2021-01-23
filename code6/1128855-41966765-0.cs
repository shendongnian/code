       using System;
       using System.Collections.Concurrent;
       using System.ComponentModel.DataAnnotations;
       using System.Data.Entity;
       using System.Data.Entity.Infrastructure;
       using System.Data.Entity.ModelConfiguration;
       
       namespace Utilities
       {
           public class FooContext : DbContext
           {
               public DbSet<Foo> Foo { get; set; }
       
               static public FooContext Spawn(string schemaName, string tablename) //minifactory
               {
                   if (string.IsNullOrEmpty(schemaName?.Trim())) throw new ArgumentException(nameof(schemaName));
                   if (string.IsNullOrEmpty(tablename?.Trim())) throw new ArgumentException(nameof(adacsTablename));
       
                   var dummyDbContext = new DbContext("name=NameOfConnectionStringFromWebConfig"); //0 stupidhack for retrieving the connection
       
                   return new FooContext(dummyDbContext, GetModelBuilderAndCacheIt(schemaName, tablename).Build(dummyDbContext.Database.Connection).Compile());
               }
               //0 stupidhack over EntityConnection("name=NameOfConnectionStringFromWebConfig") which wasnt working because it demands metadata on the codefirst connection
       
               private static readonly object DbCompiledModelRegistrarLocker = new object(); // ReSharper disable InconsistentlySynchronizedField
               private static readonly ConcurrentDictionary<Tuple<string, string>, DbModelBuilder> DbModelBuilderCache = new ConcurrentDictionary<Tuple<string, string>, DbModelBuilder>();
               static private DbModelBuilder GetModelBuilderAndCacheIt(string schemaName, string adacsTablename) //0
               {
                   var key = Tuple.Create(schemaName, adacsTablename);
                   if (DbModelBuilderCache.ContainsKey(key))
                       return DbModelBuilderCache[key];
       
                   lock (DbCompiledModelRegistrarLocker)
                   {
                       if (DbModelBuilderCache.ContainsKey(key))
                           return DbModelBuilderCache[key];
       
                       var modelBuilder = new DbModelBuilder();
                       modelBuilder.Configurations.Add(new FooFluentConfiguration(schemaName, adacsTablename));
       
                       DbModelBuilderCache[key] = modelBuilder;
       
                       return modelBuilder;
                   }
               }
               //0 building the same model over and over is very expensive operation and this is why we resorted to caching the modelbuilders
               // ReSharper restore InconsistentlySynchronizedField
       
               private DbContext _dummyDbContext;
               private FooContext(DbContext dummyDbContext, DbCompiledModel compiledModel)
                   : base(dummyDbContext.Database.Connection, compiledModel, contextOwnsConnection: true)
               {
                   _dummyDbContext = dummyDbContext;
       
                   Database.SetInitializer<FooContext>(strategy: null); //0
               }
               //0 http://stackoverflow.com/a/39710954/863651   ef by default attempts to create the database if it doesnt exist
               //  however in this case we want ef to just do nothing if the underlying database doesnt exist
       
               //protected override void OnModelCreating(DbModelBuilder modelBuilder) //0 here be dragons   beware that this approach wont work as intended down the road
               //{
               //    modelBuilder.Configurations.Add(new FooFluentConfiguration(_schemaName, _adacsTableName)); //0 here be dragons   beware that this approach wont work as intended down the road
               //    base.OnModelCreating(modelBuilder);
               //}
       
               protected override void Dispose(bool disposing)
               {
                   if (disposing)
                   {
                       _dummyDbContext?.Dispose();
                       _dummyDbContext = null;
                   }
       
                   base.Dispose(disposing);
               }
           }
       
           public sealed class FooFluentConfiguration : EntityTypeConfiguration<Foo>
           {
               public FooFluentConfiguration(string schemaName, string tableName)
               {
                   HasKey(t => t.Id);
       
                   ToTable(schemaName: schemaName, tableName: tableName);
               }
           }
       
           public class Foo
           {
               [Key]
               [Required]
               public string Id { get; set; }
       
               [Required]
               public string Name { get; set; }
           }
       }
