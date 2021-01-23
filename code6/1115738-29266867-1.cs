    public class ManufacturerEntityService : BaseEntityService<Manufacturer>
    {
        Entities entities = new Entities();
    
        protected override ObjectSet<Manufacturer> EntitySet
        {
            get 
            { 
                ObjectContext objectContext = entities.ObjectContext;  
                return objectContext.CreateObjectSet<Manufacturer>("Manufacturers");
            }
        }
    
    }
