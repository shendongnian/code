    public class IndexPageModel
    {
       public int PersonId {get;set;}
    }
    
    [HttpGet]
    public ViewResult IndexPage()
    {
        ViewBag.PersonList = new List<Person>{ ... };
        return new View();
    }
    
    [HttpPost]
    public ActionResult IndexPage(IndexPageModel model)
    {
        model.PersonId // Got it!
    }
    
