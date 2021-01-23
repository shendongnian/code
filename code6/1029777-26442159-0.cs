    public class AModelDataBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(AModel))
            {
                var request = controllerContext.HttpContext.Request;
                string normal = request.Form.Get("normalproperty");
                string abnormal = request.Form.Get("abnormal-property");
                return new AModel
                {
                    NormalProperty = normal,
                    AbnormalProperty = abnormal
                };
            }
        
            return base.BindModel(controllerContext, bindingContext);
        }
    }
