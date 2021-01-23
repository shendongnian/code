    public class MyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            // Default binder
            var temp = base.BindModel(controllerContext, bindingContext);
            
            var nulledValue = request.QueryString["test"];
            if (nulledValue == "0.0")
            {
                // cast your temp to MyInvoice and set the property here...
            }
            return temp;
        }
    }
