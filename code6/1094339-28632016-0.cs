        private FormValueProvider vp;
      
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeValue = bindingContext.ValueProvider.GetValue("ModelType");
                    
            var type = Type.GetType(
                (string)typeValue.ConvertTo(typeof(string)),
                true
            );
            if (!typeof(ModelBase).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("Bad Type");
            }
           
            var model = Activator.CreateInstance(type);
            vp = new FormValueProvider(controllerContext);
            bindingContext.ValueProvider = vp;
            this.SetModelPropertValues(model);
          
            return model;        
        }
