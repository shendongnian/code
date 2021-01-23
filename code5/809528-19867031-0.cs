    public class SearchOptionsDataBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(SearchOptions))
            {
                var baseResult = base.BindModel(controllerContext, bindingContext);
                HttpRequestBase request = controllerContext.HttpContext.Request;
                baseResult.Contracts.Clear();
                
                foreach(var val in request.QueryString.GetValues("contracts"))
                {
                      baseResult.Add(GetContractTypeByCode(val));
                }
                 
                return baseResult;
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    } 
