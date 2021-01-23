    public class MyModel
    {
      public string Name {get;set;}
    }
    public class MyController
    {
      public ActionResult MyAction
      {
         var account = service.GetCrmEntity("account", myaccountId);
    
         var myModel = new MyModel();
         myModel.Name = account.name;
    
         return View(myModel)
      }
    }
