    public class YourController : Controller
    {
     IDataRepository db;
    
     public YourController(IDataRepository db)
     {
      this.db = db; 
     }
     
     public ViewResult Index()
     {
      YourModel model = db.LoadData();
      return View(model);
     }
    }
