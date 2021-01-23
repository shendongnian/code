          public class QueryStringToDictionaryBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var collection = controllerContext.HttpContext.Request.QueryString;
            var modelKeys =
                collection.AllKeys.Where(
                    m => m.StartsWith(bindingContext.ModelName));
            var dictionary = new Dictionary<int, string>();
            foreach (string key in modelKeys)
            {
                var splits = key.Split(new[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
                int nummericKey = -1;
                if(splits.Count() > 1)
                {
                    var tempKey = splits[1]; 
                    if(int.TryParse(tempKey, out nummericKey))
                    {
                        dictionary.Add(nummericKey, collection[key]);    
                    }   
                }                 
            }
            return dictionary;
        }
    }
