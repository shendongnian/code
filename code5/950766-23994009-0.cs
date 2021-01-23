    public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Message = "Test webservices";
    
                return View();
    
            }
            public ActionResult getConfig()
            {
              return View();
            }
    
        [HttpPost]
               public ActionResult getConfig(FormCollection Form)
                {
                  if(Form["BtnSave"]!=null)
                   {
        
                    string totalRecords = string.Empty;
        
                    wsConfig.config_pttClient client = new wsConfig.config_pttClient();
                    wsConfig.getConfigInput gci = new wsConfig.getConfigInput();
                    wsConfig.getConfigOutput gco = new wsConfig.getConfigOutput();
        
                    gco = client.getConfig(gci);
        
                    totalRecords = gco.result.totalRecords.ToString();
        
                    ViewBag.totalRecords = totalRecords;
                  }
                  return View();
                }
