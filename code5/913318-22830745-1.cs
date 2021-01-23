    goo g = new goo();
    
    PropertyInfo pInfo = g.GetType().GetProperty("f");
    object f = Activator.CreateInstance(pInfo.PropertyType);
    PropertyInfo pInfo2 = f.GetType().GetProperty("Name");
    pInfo2.SetValue(f, "Hello");
    pInfo.SetValue(g, f);
