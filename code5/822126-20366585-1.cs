    public class MyController:AsyncController
    {
        public async Task<ActionResult> IndexAsync()
        {
           return View(); //view called "Index.cshtml", not "IndexAsync.cshtml"
        }
    }
