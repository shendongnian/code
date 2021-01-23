    [HttpPost]
    // Note how the argument name is "items"
     public ActionResult MyItems(List<Item> items)
     {
         // set a breakpoint and check the items List
         return Content("success")
     }
    public class Item
    {
    // Make sure to use public properties get/set
        public string Category {get;set;}
    }
