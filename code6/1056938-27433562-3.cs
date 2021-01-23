    public class ControlViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult formIdResult = bindingContext.ValueProvider.GetValue("FormId");
            if (formIdResult == null)
                return null;
            long formId = long.Parse(formIdResult.AttemptedValue);
            ValueProviderResult controlIdResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".Id");
            if (controlIdResult == null)
                return null;
            int controlId = int.Parse(controlIdResult.AttemptedValue);
            FormViewModel form;
            ControlViewModel model = FormControlManager.GetControl(formId, controlId, out form);
            if (model == null)
                return null;
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType());
            return base.BindModel(controllerContext, bindingContext);
        }
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            // need to skip properties that aren't part of the request, else we might hit a StackOverflowException
            string fullPropertyKey = _buildPropName(bindingContext.ModelName, propertyDescriptor.Name);
            if (!bindingContext.ValueProvider.ContainsPrefix(fullPropertyKey))
            {
                return;
            }
            // call into the property's model binder
            object originalPropertyValue = propertyDescriptor.GetValue(bindingContext.Model);
            ModelMetadata propertyMetadata = bindingContext.PropertyMetadata[propertyDescriptor.Name];
             
            // If it is not an IEnumerable we can make the default Function do its magic
            if (!(originalPropertyValue is IEnumerable<ControlViewModel>))
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            else
            {
                // Else we need to call the BindModel method for each Member of the Sequence.
                int index = 0;
                foreach (ControlViewModel value in (IEnumerable<ControlViewModel>)originalPropertyValue)
                {
                    propertyMetadata.Model = value;
                    ModelBindingContext innerBindingContext = new ModelBindingContext()
                    {
                        ModelMetadata = propertyMetadata,
                        ModelName = fullPropertyKey + (index > -1 ? String.Format("[{0}]", index++) : null),
                        ModelState = bindingContext.ModelState,
                        ValueProvider = bindingContext.ValueProvider
                    };
                    BindModel(controllerContext, innerBindingContext);
                }
            }
                
        }
        static string _buildPropName(string prefix, string propertyName)
        {
            if (String.IsNullOrEmpty(prefix))
            {
                return propertyName;
            }
            else if (String.IsNullOrEmpty(propertyName))
            {
                return prefix;
            }
            else
            {
                return prefix + "." + propertyName;
            }
        }
