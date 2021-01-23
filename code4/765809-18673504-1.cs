        public class SelectedProductModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            SelectedProduct selectedProduct = new SelectedProduct();
            if (value.AttemptedValue != null && ! "".Equals(value.AttemptedValue))
                selectedProduct.Id = (int)value.ConvertTo(typeof(int));
            else
                selectedProduct.Id = null;
            return selectedProduct;
        }
    }
