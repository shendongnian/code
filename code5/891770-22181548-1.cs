private void ProcessDateTimeProperties(object obj, ActionExecutedContext filterContext, HashSet&lt;object> processedObjects = null)
    {
        if (processedObjects == null)
            processedObjects = new HashSet&lt;object>();
        if (processObjects.Contains(obj))
            return;
        processedObjects.Add(obj);
        var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in properties)
        {
            var t = property.PropertyType;
            if (t.IsPrimitive || t == typeof(string) || t == typeof(Enum))
                continue;
            var p = property;
            if (p.PropertyType == typeof(DateTime))
            {
                var date = (DateTime)p.GetValue(obj, null);
                date.AddMinutes((int)filterContext.HttpContext.Cache["offset"]);
                p.SetValue(obj, date, null);
            }
            // Same check for nullable DateTime.
            else if (p.PropertyType == typeof(Nullable<DateTime>))
            {
                var date = (DateTime?)p.GetValue(obj, null);
                if (!date.HasValue) continue; ;
                date.Value.AddMinutes((int)filterContext.HttpContext.Cache["offset"]);
                p.SetValue(obj, date, null);
            }
            else
            {
                var v = property.GetValue(obj, null);
                if (v != null)
                    ProcessDateTimeProperties(v, filterContext, processedObjects);
            }
        }
    }
