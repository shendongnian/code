    public class MyViewModel
    {
         //My fields which I want to pass to View
         etc
         etc
    }
    public ActionResult Index()
    {
          DataRerieveClient _proxy = new DataRerieveClient();
          var orderDetails = _proxy.GetProductDetails(null);
                
          MyViewModel.Field1 = orderDetails.Field1; //set all feilds like that      
    
          return View(MyViewModel); // Pass View Model to View
    }
