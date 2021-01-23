    foreach(var item in report.Items)
    {
        dynamic dynamicObject = new ExpandoObject();
        var dic = dynamicObject as IDictionary<string, object>;
        var properties = item.GetType().GetProperties();
        foreach(PropertyInfo property in properties)
        {
            dic[property.Name] = property.GetValue(item, null);
        }
        // At this stage the dynamicObject will contain properties with correct
        // names and types
        results.Add(dynamicObject);
    }
