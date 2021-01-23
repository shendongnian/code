    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    
    namespace Split
    {
        class Program
        {
            static void Main()
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
    
                const int id = 1;
                const string split = "Info"; // contract: if the entity being delete has an Info property then the row has been splitted
    
                using (var context = new DataContext()) // Add
                {
                    var product = new Product 
                    {
                        Name = "my Article 1",
                        Info = new ProductInfo { PhotoUrl = "http://myphoto.jpg" } // when adding a new entity the related subEntity MUST BE included on the graph
                    };
    
                    context.Products.Add(product);
                    context.SaveChanges();
                }
    
                using (var context = new DataContext())
                {
                    var product = context.Products.Find(id);
                    context.Entry(product).Reference(e => e.Info).Load(); // when modifiying an entity the related subEntity COULD BE OR NOT included on the graph, no need to include it if we are not going to modify the subEntity
    
                    product.Name = "MY ARTICULE 1";
                    product.Info.PhotoUrl = "HTTP://MYPHOTO.JPG";
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                }
    
                using (var context = new DataContext())
                {
                    PropertyInfo propertyInfo;
    
                    // context.Products.Find(id); // uncoment bring it to memory and test with entity in memory
    
                    var entity = context.Products.Local.FirstOrDefault(e => e.Id == id);
    
                    if (entity != null)                                      // there is a entity already yet in memory
                    {
                        propertyInfo = entity.GetType().GetProperty(split);  // contract
    
                        if (propertyInfo != null)
                            propertyInfo.SetValue(entity, null);             // remove subEntity and relationship
    
                        context.Entry(entity).State = EntityState.Detached;  // remove entity from ChangeTracker API
                    }
    
                    entity = new Product { Id = id };                        // new entity stub
                    propertyInfo = entity.GetType().GetProperty(split);      // contract:
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entity, null);                 // remove subEntity and and relationship
    
                        var subEntity = Activator.CreateInstance(propertyInfo.PropertyType); // create a new subEntity stub
                        subEntity.GetType().GetProperty("Id").SetValue(subEntity, id);       // set the foreinkey relation
                        context.Entry(subEntity).State = EntityState.Deleted;                // mark as deleted on context
                    }
    
                    context.Entry(entity).State = EntityState.Deleted;       // delete the entity
                    context.SaveChanges();
                }
            }
        }
    
        class Product
        {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
    
            public virtual ProductInfo Info { get; set; }
        }
    
        class ProductInfo
        {
            public virtual int Id { get; set; }
            public virtual string PhotoUrl { get; set; }
            public virtual Product Product { get; set; }
        }
    
        class DataContext : DbContext
        {
            public DataContext()
                : base("name=DefaultConnection")
            {
                Configuration.ProxyCreationEnabled = false;
                Configuration.LazyLoadingEnabled = false;
    
    
            }
            public DbSet<Product> Products { get; set; }
            public DbSet<ProductInfo> ProductInfos { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Product>() // one-to-one
                    .ToTable("Products")
                    .HasKey(e => e.Id)
                    .HasRequired(e => e.Info)
                    .WithRequiredDependent(e => e.Product);
    
                modelBuilder.Entity<ProductInfo>() // map to the same table Products
                    .ToTable("Products")
                    .HasKey(e => e.Id);
    
                base.OnModelCreating(modelBuilder);
            }
    
        }
    }
