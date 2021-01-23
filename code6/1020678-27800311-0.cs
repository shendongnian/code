    Use custom model binder for that-
    
    public class yourmodel
    {
    public int cellphone{get;set;}
    }
    
    Define custom model binder as
    public class CustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
    
            string[] phoneArray= request.Form.Get("CellPhone").split('-');
    
            string phone=phoneArray[0]+phoneArray[1];
    
            return new yourmodel
                       {
                           cellphone= convert.ToInt32(phone)
                       };
        }
    } 
    
    
    then in app_start register new created binder as
    protected void Application_Start()
    {
     
        ModelBinders.Binders.Add(typeof(yourmodel), new CustomBinder());
    }
    
    and in controller 
    [HttpPost]
    public ActionResult Index([ModelBinder(typeof(CustomBinder))] yourmodel model)
    {
        
        //..processing code
    }
