    public class MyController {
        IDataAccessLayer _dataAccessLayer;
    
        public MyController(IDataAccessLayer dataAccessLayer) {
            _dataAccessLayer = dataAccessLayer;
        }
        public ActionResult Create(Model myModel){
            _dataAccessLayer.InsertIntoDatabase(myModel);
            return View();
        }
    }
