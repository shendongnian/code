    public class EfPurchaseRecordsRepository: IPurchaseRecordsRepository
    {
       private readonly EfObjectContext _objectContext;
       public EfPurchaseRecordsRepository(string connectionString)
       {
          _objectContext = new EfObjectContext(connectionString);
       }
    
       public IEnumerable<PurchaseRecordsDomainModel > GetPurchaseRecords()
       {
          var purchaseRecords = (from p in _objectContext.PurchaseRecords
                                ....
                                select p).AsEnumerable();
    
          return purchaseRecords .Select(p => p.ConvertToDomainPurchaseRecord());
       }
    }
