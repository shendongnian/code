     public class SchedulingController : Controller
        {
            //
            // GET: /Scheduling/
    
            public ActionResult Index()
            {
                return View();
            }
    
            public JsonResult GetAll([DataSourceRequest] DataSourceRequest request)
            {
                var e = new List<Events>
                {
                    new Events
                    {
                        Id =1,
                        Title="Testing 1",
                        Start= DateTime.Now.AddHours(1),
                        End = DateTime.Now.AddHours(2),
                        IsAllDay = false
                        
                    },
                    new Events
                    {
                        Id=2,
                        Title="Testing 2",
                        Start = DateTime.Now.AddHours(3),
                        End = DateTime.Now.AddHours(4),
                        IsAllDay = false
                    }
                };
    
                return Json(e.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
    
        }
