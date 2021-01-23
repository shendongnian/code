    public class MyController: Controller
    {
        (constructor here)
        public JsonResult MyAction ()
        {
            var data = new List<object>();
            for (var j = 0; j < items.Count(); j++) 
            { 
                var temp = groups.Where(customfilter); 
                data.Add(temp);
            }
            return Json (myList, JsonRequestBehavior.AllowGet);
        }
    }
