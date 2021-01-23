    Dictionary<string, string> kvps = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(actionContext.Request.RequestUri.Query))
            {
                kvps = actionContext.Request.GetQueryNameValuePairs().ToDictionary(a=>a.Key,a=>a.Value);
            }
            //Check and get source data from body 
            else if (actionContext.Request.Content.IsFormData())
            {
                var bodyString = actionContext.Request.Content.ReadAsStringAsync().Result;
                try
                {
                    kvps = ConvertToKvps(bodyString);
                }
                catch (Exception ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
                    return false;
                }
            }
            else
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "No input data");
                return false;
            }
            Object obj = null;
            
            try
            {
                obj = new Something(kvps);//build your object by key value pairs
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, ex.Message);
                return false;
            }
            
            bindingContext.Model = obj;
            return true;
