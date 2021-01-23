    public class CustomModelBinder : System.Web.Mvc.IModelBinder
    {
       public object BindModel(ControllerContext controllerContext, 
                   ModelBindingContext bindingContext)
     {
        Ownership own = new Ownership();
        own.name = controllerContext.HttpContext.Request.Form["fName"];
        own.email = controllerContext.HttpContext.Request.Form["fEmail"];
        own.PhoneNo = controllerContext.HttpContext.Request.Form["fPhoneNo"];
        own.country = controllerContext.HttpContext.Request.Form["Country"];
        own.address = controllerContext.HttpContext.Request.Form["Adres"];
        own.office = controllerContext.HttpContext.Request.Form["Off"];
        own.officeEmail = controllerContext.HttpContext.Request.Form["OffEmail"];
        own.officeNo = controllerContext.HttpContext.Request.Form["OffNo"];
        own.OwnershipType = controllerContext.HttpContext.Request.Form["OwnershipType"];
        own.ProductId = controllerContext.HttpContext.Request.Form["ProductId"];
        return own;
    }
    }
