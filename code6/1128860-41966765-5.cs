         using System;
         using System.Collections.Concurrent;
         using System.ComponentModel.DataAnnotations;
         using System.Data.Common;
         using System.Data.Entity;
         using System.Data.Entity.Infrastructure;
         using System.Data.Entity.ModelConfiguration;
         
         namespace Utilities
         {
             // usage:
             //
             // var context1 = new FooContext("Schema1", "PingTable1", "PongTable1");
             // context1.Ping.Select(x => x.Id > 10).ToList();	   
             // context1.Pong.Select(x => x.Id > 20).ToList();
         
             public class FooContext : DbContext
             {
                 public DbSet<Ping> Ping { get; set; }
                 public DbSet<Pong> Pong { get; set; }
         
                 static public FooContext Spawn(string nameOrConnectionString, string pingTablename, string pongTablename, string schemaName = null) //minifactory
                 {
                     //if (string.IsNullOrWhiteSpace(schemaName?.Trim())) throw new ArgumentException(nameof(schemaName)); //canbe
                     if (string.IsNullOrWhiteSpace(pingTablename?.Trim())) throw new ArgumentException(nameof(pingTablename));
                     if (string.IsNullOrWhiteSpace(pongTablename?.Trim())) throw new ArgumentException(nameof(pongTablename));
         
                     var dummyDbContext = new DbContext(nameOrConnectionString); //0 stupidhack for retrieving the connection
         
                     return new FooContext(dummyDbContext, GetModelBuilderAndCacheIt(dummyDbContext.Database.Connection, pingTablename, pongTablename, schemaName));
                 }
         
                 //0 stupidhack over EntityConnection("name=NameOfConnectionStringFromWebConfig") which wasnt working because it demands metadata on the codefirst connection to an oracle db (at least oracledb ver11 - go figure ...)
         
                 private static readonly object DbCompiledModelRegistrarLocker = new object(); // ReSharper disable InconsistentlySynchronizedField
                 private static readonly ConcurrentDictionary<Tuple<string, string, string>, DbCompiledModel> DbModelBuilderCache = new ConcurrentDictionary<Tuple<string, string, string>, DbCompiledModel>();
         
                 static private DbCompiledModel GetModelBuilderAndCacheIt(DbConnection databaseConnection, string pingTablename, string pongTablename, string schemaName) //0
                 {
                     var key = Tuple.Create(pingTablename, pongTablename, schemaName);
                     if (DbModelBuilderCache.ContainsKey(key))
                         return DbModelBuilderCache[key];
         
                     lock (DbCompiledModelRegistrarLocker)
                     {
                         if (DbModelBuilderCache.ContainsKey(key))
                             return DbModelBuilderCache[key];
         
                         var modelBuilder = new DbModelBuilder();
                         modelBuilder.Configurations.Add(new PingFluentConfiguration(schemaName, pingTablename));
                         modelBuilder.Configurations.Add(new PongFluentConfiguration(schemaName, pongTablename));
         
                         //setting a maxsize for the cache so that least used dbmodels get flushed away is left as an exercise to the reader
                         return DbModelBuilderCache[key] = modelBuilder.Build(databaseConnection).Compile();
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
                 //    modelBuilder.Configurations.Add(new PingFluentConfiguration(_schemaName, _tablename)); //0 here be dragons   beware that this approach wont work as intended down the road
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
         
             public sealed class PingFluentConfiguration : EntityTypeConfiguration<Ping>
             {
                 public PingFluentConfiguration(string schemaName, string tableName)
                 {
                     HasKey(t => t.Id);
         
                     ToTable(schemaName: schemaName, tableName: tableName);
                 }
             }
         
             public sealed class PongFluentConfiguration : EntityTypeConfiguration<Pong>
             {
                 public PongFluentConfiguration(string schemaName, string tableName)
                 {
                     HasKey(t => t.Id);
         
                     ToTable(schemaName: schemaName, tableName: tableName);
                 }
             }
         
             public class Ping
             {
                 [Key]
                 [Required]
                 public string Id { get; set; }
         
                 [Required]
                 public string Name { get; set; }
             }
         
             public class Pong
             {
                 [Key]
                 [Required]
                 public string Id { get; set; }
         
                 [Required]
                 public string Name { get; set; }
             }
         }
