    public class MyController
    {
    	public ActionResult MyView()
    	{
    		var myModel = new MyModel(true);
    		
    		return View(myModel);
    	}
    	
    	[HttpPost]
    	public ActionResult MyView(MyModel myModel)
    	{
    		myModel.RefreshReport();
    		
    		return View(myModel);
        }
    }
