    public class MemberController 
    {
       public MemberManager MemberManager {get;set;}
    
       public ActionResult View(int id)
       { 
         var viewModel = MemberManager.Get(id);
         return View(viewModel);
       } 
    }
