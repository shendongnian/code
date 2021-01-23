    public class LoggingDataBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
             LogMethod("Logging here");
             return base.BindModel(controllerContext, bindingContext);
        }
    } 
