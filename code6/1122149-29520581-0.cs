    public class InjectedObjectModelBinder : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(InjectedObject))
            {
                return false;
            }
            IEnumerable<string> values;
            string keyValue = "";
            if (actionContext.Request.Headers.TryGetValues("your_key", out values))
            {
                keyValue = values.First();
            }
            bindingContext.Model = new InjectedObject() { Id = 789, Name = keyValue };
            return true;
        }
    }
