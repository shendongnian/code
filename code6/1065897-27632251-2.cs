    [RoutePrefix("item")]
    public class ItemController : Controller
    {
        // /item/edit/1/price
        // would result in invocation of
        // this method with itemid = 1 , desc = "price"
        [Route("edit/{itemid}/{desc}")]
        public ActionResult(int itemid, string desc) 
        {
            //code here
        }
    }
