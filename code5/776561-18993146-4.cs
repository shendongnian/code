    public static class ServiceHelper
    {
        public static object BuildResponseObject<T>(T typedObject, NameValueCollection queryString) where T: BaseResponse
        {
            var newObject = new ExpandoObject() as IDictionary<string, object>;
            newObject.Add("href", typedObject.href);
            if (!String.IsNullOrEmpty(queryString.Get("fields")))
            {
                foreach (var propertyName in queryString.Get("fields").Split(',').ToList())
                {
                    //could check for 'socialNetwork' and exclude if you wanted
                    newObject.Add(propertyName, typedObject.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(typedObject, null));
                }
            }
            if (!String.IsNullOrEmpty(queryString.Get("expand")))
            {
                foreach (var propertyName in queryString.Get("expand").Split(',').ToList())
                {
                    newObject.Add(propertyName, typedObject.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(typedObject, null));
                }
            }
            return newObject;
        }
    }
