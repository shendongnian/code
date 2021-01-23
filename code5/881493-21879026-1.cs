    public class MyViewModel // Whatever name you want to give
    {
         //My fields which I want to pass to View
         publis string Field1{get;set;}
         etc
         etc
    }
    public ActionResult Index()
    {
          DataRerieveClient _proxy = new DataRerieveClient();
          var orderDetails = _proxy.GetProductDetails(null);
          
          MyViewModel viewModel = new MyViewModel(); //Create an object of your ViewModel
      
          viewModel.Field1 = orderDetails.Field1; //set all feilds like that      
    
          return View(MyViewModel); // Pass View Model to View
    }
