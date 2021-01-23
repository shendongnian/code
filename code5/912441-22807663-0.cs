    public class TagListModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor )
        {
            if (propertyDescriptor.PropertyType == typeof(TagList))
            {
                ValueProviderResult value = bindingContext.ValueProvider.GetValue(propertyDescriptor.Name);
                string[] rawTags = value.ToString().Split(',');
                TagList tags = new TagList();
                foreach (string rawTag in rawTags)
                { 
                    // for numbers - get them from DB
                    // for strings - create new and store in DB
                    // then add them to tags
                }
                propertyDescriptor.SetValue(bindingContext.Model, tags);
            }
            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor)
            }
        }
    }
