    public class PurchaseController: Controller
    {
       private readonly IPurchaseRecordsRepository _repository;
    
       public PurchaseController(IPurchaseRecordsRepository repository)
       {
          if(repository == null)
          {
             throw new ArgumentNullException("repository");
          }
          _repository = repository;
       }
    
       public ActionResult Index()
       {
          var purchaseRecordsService = new PurchaseRecordsService(_repository);
          
          var purchaseRecordsViewModel = new PurchaseRecordsViewModel();
    
          var purchaseRecords = purchaseRecordsService.GetPurchaseRecords();
    
          foreach(var purchaseRecord in purchaseRecords)
          {
              var purchaseRecordViewModel = new PurchaseRecordViewModel(purchaseRecord);
              purchaseRecordsViewModel.PurchaseRecords.Add(purchaseRecordViewModel);
          }
         
          return View(purchaseRecordsViewModel);
       }
    }
