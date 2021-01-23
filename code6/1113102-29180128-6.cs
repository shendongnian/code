    Assembly otherAssembly = typeof(/* a class of the other assembly */).Assembly;
    AppDomain.CurrentDomain.FirstChanceException += (sender, fceea) =>
    {
        AppDomain domain = (AppDomain)sender;
        var method = fceea.Exception.TargetSite;
        var declaringType = method.DeclaringType;
        var assembly = declaringType.Assembly;
        if (assembly == otherAssembly)
        {
            // Log the stacktrace of the Exception, or whatever 
            // you want
        }
    };
