    public class DBController : Controller
    {
        XXXXXXXEntities xXXXXXEntities = new XXXXXXXEntities();
    
        public IEnumerable<usp_xxxxx_Result> usp_xxxxx()
        {
            return XXXXXEntities.usp_xxxxx();
        }
    }
    
    public ActionResult ViewQuery() {
        DBController dBController = new DBController();
        return dBController.usp_xxxxx().ToArray();
    }
