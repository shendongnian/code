    goo g = new goo();
    g.f = new foo { Name = "Hello" };
    
    PropertyInfo pInfo = g.GetType().GetProperty("f");
    object f = pInfo.GetValue(g);
    PropertyInfo pInfo2 = f.GetType().GetProperty("Name");
    string name = (string)pInfo2.GetValue(f);
