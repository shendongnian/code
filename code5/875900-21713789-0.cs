    URL:
    http:localhost/sandbox?intValue=123&decimalValue=3.14&boolValue=true
    C#    
    public const string Q = "intValue";
    public const string R = "decimalValue";
    public const string S = "boolValue";
    if (((Page.Request.QueryString[Q] != null)))
        ...
    if (((Page.Request.QueryString[R] != null)))
        ...
    if (((Page.Request.QueryString[S] != null)))
        ...
