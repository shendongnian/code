    using System.Data.Metadata.Edm;
    using System.Data.Objects;
    using System.Data.Entity.Infrastructure;
    
    ...
    
    using (dbcontext context = new TestContext())
    {
       ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
       MetadataWorkspace workspace = objContext.MetadataWorkspace;
       IEnumerable<EntityType> tables = workspace.GetItems<EntityType>(DataSpace.SSpace);
    
    }
