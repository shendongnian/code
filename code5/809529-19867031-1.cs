    public class SearchOptionsDataBinder : DefaultModelBinder
    {
      public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
      {
        if (bindingContext.ModelType == typeof(SearchOptions))
        {
          var baseResult = (SearchOptions)base.BindModel(controllerContext, bindingContext);
          var request = controllerContext.HttpContext.Request;
          
          baseResult.Contracts = request.QueryString
                                        .GetValues("contracts")
                                        .Select(GetContractTypeByCode)
                                        .Where(c => !string.IsNullOrEmpty(c.Code))
                                        .ToArray();
          return baseResult;
        }
        return base.BindModel(controllerContext, bindingContext);        
      }
    } 
