	public class PolisModelBinder : System.Web.Mvc.IModelBinder
	{
	   public object BindModel(ControllerContext controllerContext, 
								ModelBindingContext bindingContext)
		{
			 var form = controllerContext.HttpContext.Request.Form;
			 //use hidden value to determine the model
			 if(form.Get("PolisType") == "SubClassA") 
			 {
				//bind SubPolisA
			 }
			 else 
			 {
				//bind SubPolisB
			 }
		}
	}
