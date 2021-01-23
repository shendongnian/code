    void IResultFilter.OnResultExecuting (ResultExecutingContext filterContext)        
    {
          // code
          var jsonResult = (JsonResult)filterContext.Result;
          var model = (ProjectName.Models.ModelName)jsonResult.Data;
          var propertyValue = model.PropertyName;
          // code
    }
