    public class InventoryRepository : GenericRepository<ComputerEntity>, IInventoryRepository
    {
        public InventoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
      // your custom methods go here
     }
