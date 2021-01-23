    public static bool RequestIsValid(IRequest preAuthorizeRequest)
    {
        var member = typeof (YourType).GetMethod(
            "RequestIsValid",
            BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public,
            null,
            new [] {preAuthorizeRequest.GetType()},
            null);
        if (member.GetParameters()[0].ParameterType != typeof (IRequest))
        {
            member.Invoke(null, new[] {Convert.ChangeType(preAuthorizeRequest, preAuthorizeRequest.GetType())});
        }
        // default
    }
