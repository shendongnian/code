    foreach (var dirtyField in allDirtyFields)
    {
        PropertyInfo p = null;
        if (!personProps.ContainsKey(dirtyField))
        {
            p = p2.GetType().GetProperty(dirtyField);
            personProps.Add(dirtyField, p);
        }
        else
        {
            p = personProps[dirtyField];
        }
        p.SetValue(p2, p.GetValue(p1));
    }
