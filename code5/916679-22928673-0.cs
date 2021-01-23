    foo query = db.foo.Where(x => x.Id == list.Id).FirstOrDefault();
    if(query != null)
    {
        properties = query.GetType().GetProperties();
        foreach(PropertyInfo prop in properties)
        {
            if (list.GetType().GetProperty(prop.Name) != null)
            {
                var val1 = list.GetType().GetProperty(prop.Name).GetValue(list);
                var val2 = prop.GetType().GetProperty(prop.Name).GetValue(prop);
                // do your checking here
            }
        }
    }
