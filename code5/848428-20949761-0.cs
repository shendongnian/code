    var type = typeof(CommonAppearance);
    var methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
    foreach (Control ctr in lstControls)
    {
       var setAppearanceMethod = 
            methods.FirstOrDefault(m => m.GetParameters()[0].ParameterType == ctr.GetType());
       if(setAppearanceMethod!=null)
           setAppearanceMethod.Invoke(null, new[] { item });
    }
