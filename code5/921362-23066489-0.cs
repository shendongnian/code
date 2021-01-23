    public class CriteriaModelBinder : IModelBinder
    {
        public bool BindModel(
            HttpActionContext actionContext,
            ModelBindingContext bindingContext
        )
        {
            if (bindingContext.ModelType != typeof (CriteriaModel))
            {
                return false;
            }
            var value = bindingContext.ValueProvider.GetValue("Categories");
            if (value == null)
            {
                return false;
            }
            var categoryJson = value.RawValue as IEnumerable<string>;
            if (categoryJson == null)
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Categories cannot be null.");
                return false;
            }
            
            var categories = categoryJson
                .Select(JsonConvert.DeserializeObject<CriteriaCategory>)
                .ToList();
            bindingContext.Model = new CriteriaModel {Categories = categories};
            return true;
        }
    }
