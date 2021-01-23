    public class MyNewController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpPost]
        public ActionResult PerformSomeAction(int id)
        {
            var model = new MyNewModel()
            {
                Id = id
            };
            
            return View(model);
        }
    }
