    public class JamesDropDownController 
    {
     public ActionResult GetList()
     {
      List<SelectItem> allItems= new List<SelectItem>(); // from DB
      return View("JamesDropDown", allItems);
     }
    }
