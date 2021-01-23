        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Product))
            {
                return false;
            }
            var id = (int)bindingContext.ValueProvider.GetValue("productId").ConvertTo(typeof(int));
            // Create instance of your object
            bindingContext.Model = new Product { Id = id };
            return true;
        }
    }
