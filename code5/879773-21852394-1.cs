     public class testController
     {       
          public ActionResult testMethod()
          {
              ViewBag.someData = // get data from database using Linq or SQL Query
              // or you can use Model/ModelView
              return View(model)
          }    
     }
