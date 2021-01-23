    public class SomeController
    {
        public ActionResult Grid(int id)
        {
              var list = // Logic code to fill the items
              return View("_AssetHistoryRecordsPartial", list);
        }
     }
