    public class MyBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string key = bindingContext.ModelName;
            var v = ((string[])bindingContext.ValueProvider.GetValue(key).RawValue)[0];
            int outPut;
            if (int.TryParse(v, NumberStyles.AllowThousands, new CultureInfo("en-US"), out outPut))
               return outPut;
            return base.BindModel(controllerContext, bindingContext);
        }
    }
    
    ModelBinders.Binders.Add(typeof(int), new MyBinder());
