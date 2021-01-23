    Type t = serverContext.DataWorkspace.ApplicationData.GetType();
    PropertyInfo[] pInfo = t.GetProperties();
    foreach (var p in pInfo)
    {
        // p is equal to {Microsoft.LightSwitch.Framework.EntitySet`1[LightSwitchApplication.Customer] Customers}
        MethodInfo mInfo = p.PropertyType.GetMethod("GetQuery");
        var entitySet = p.GetValue(serverContext.DataWorkspace.ApplicationData); // new line
        var result = mInfo.Invoke(entitySet, null); // updated line
    }
