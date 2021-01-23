    dynamic order = new ExpandoObject();
...
     if (hasFile)
            {
                attachment = HttpContext.Current.Request.Files[0];
    
                var dict = NvcToDictionary(HttpContext.Current.Request.Form, false);
                foreach (var item in dict)
                {
                    var _json = item.Value.ToString();
                    ((IDictionary<string, object>)order)[item.Key] = JObject.Parse(_json);
                }    
            }
