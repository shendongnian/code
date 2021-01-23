    Type myType = typeof(MyType)
    MethodInfo method = myType.GetMethod('Post');
    foreach (ParameterInfo parameter in method.GetParameters())
    {
        if (parameter.IsDefined(typeof(FromUri), false))
        {
            // attempt to find value in uri
        }        
        else if (parameter.IsDefined(typeof(FromPost), false))
        {
            // from post body
        }
        else
        {
            // have to find out myself!
        }
    }
