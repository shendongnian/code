    using System.Web.Mvc;
    
    namespace WebApplication2.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View(new MyModel { FleetType = 2 });
            }
        }
    
        public class MyModel
        {
            public int FleetType { get; set; }
        }
    
        public class VehicleOwnerFleetTypeFactory
        {
            public static FleetType[] GetTypes()
            {
                return new[]
                    {
                        new FleetType {Id = 1, Type = "Type 1"},
                        new FleetType {Id = 2, Type = "Type 2"},
                        new FleetType {Id = 3, Type = "Type 3"}
                    };
            }
        }
    
        public class FleetType
        {
            public int Id { get; set; }
    
            public string Type { get; set; }
        }
    }
