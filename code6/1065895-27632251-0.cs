    [RoutePrefix("item")]
    public class Item
    {
        [Route("edit/{itemid}/{desc}")]
        public ActionResult(int itemid, string desc) 
        {
            //code here
        }
    }
