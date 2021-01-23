    public class NotificationModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var model = this.CreateModel(controllerContext,
                bindingContext, bindingContext.ModelType);
            bindingContext.ModelMetadata.Model = model;
            var formValue = bindingContext.ValueProvider
                .GetValue(this.FormField).AttemptedValue;
            var target = model.GetType().GetProperty(this.FieldToBindTo);
            target.SetValue(model, formValue);
            // Let the default model binder take care of the rest
            return base.BindModel(controllerContext, bindingContext);
        }
        private readonly string FieldToBindTo = "_3DSecureStatus";
        private readonly string FormField = "3DSecureStatus";
    }
