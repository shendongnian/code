    var useHelperGeneric = this.GetType().GetMethods().FirstOrDefault(
                   m=> m.IsGenericMethod && m.Name == "UseHelper");
    var useHelper = useHelperGeneric.MakeGenericMethod(new Type[] { helper.GetType() });
    var newFunction = (UserHelperDelegate)useHelper.MakeDelegate(typeof(UseHelperDelegate));
    
    helpersMap.Add(helper.GetType(), newFunction);
    
    newFunction(helper);
