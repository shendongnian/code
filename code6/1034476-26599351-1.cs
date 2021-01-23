    var targetMethod = typeof(External).GetMethod("ThirdPartyMethod", BindingFlags.Static | BindingFlags.Public);
    var targetGenericMethod = targetMethod.MakeGenericMethod(new Type[] { theType });
    
    var castMethod = typeof(Enumerable).GetMethod("Cast", BindingFlags.Static | BindingFlags.Public);
    var caxtGenericMethod = castMethod.MakeGenericMethod(new Type[] { theType });
