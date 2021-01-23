    public class ConditionFilterBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof (ConditionFilter))
            {
                return false;
            }
            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }
            var queryString = HttpUtility.ParseQueryString(val.RawValue.ToString());
            var conditionFilter = new ConditionFilter
            {
                Page = queryString.GetValueFromQueryString<int>("page"), 
                PageSize = queryString.GetValueFromQueryString<int>("pageSize"),
                OscarWinner = queryString.GetValueFromQueryString<bool>("oscarWinner")
             };
             bindingContext.Model = conditionFilter;
             return true;
             }
        }
    }
