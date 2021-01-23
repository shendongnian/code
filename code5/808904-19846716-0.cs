    public class MyController : Controller
    {
    public ActionResult someView(bool myBool)
    {
        if (myBool)
        {
            return View("someView");
          // or return ReddirectToAction("someAction")
        }
        else
        {
            return View();
        }
       
     }
}
