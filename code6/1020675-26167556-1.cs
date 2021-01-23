    public virtual object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            TModel model = (TModel)bindingContext.Model ?? new TModel();
            ICollection<string> propertyNames = bindingContext.PropertyMetadata.Keys;
            foreach (var propertyName in propertyNames)
            {
                string value = GetValue(bindingContext, propertyName);
                if (bindingContext.PropertyMetadata[propertyName].ModelType.Name == "Boolean")
                {
                    if (value.ToLower() == "true,false" || value.ToLower() == "false,true")
                        value = System.Web.HttpContext.Current.Request.Form.GetValues(propertyName).First();
                }
                model.SetPropertyValue(propertyName, value);
            }
            return model;
        }
