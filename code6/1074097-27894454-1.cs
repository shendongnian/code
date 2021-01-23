    public class PropertyController : Controller
    {
      [HttpPost]
      public ActionResult Industrial(Industrial model)
      {
        ...
      }
      [HttpPost]
      public ActionResult Commercial(Commercial model)
      {
        ...
      }
      // etc
    }
