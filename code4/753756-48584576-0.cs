    HttpContext.Current = new HttpContext(
    new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
    NameValueCollection headers = HttpContext.Current.Request.Headers;
    
    Type t = headers.GetType();
    const BindingFlags nonPublicInstanceMethod = BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance;
    
    t.InvokeMember("MakeReadWrite", nonPublicInstanceMethod, null, headers, null);
    t.InvokeMember("InvalidateCachedArrays", nonPublicInstanceMethod, null, headers, null);
    
    // eg. add Basic Authorization header
    t.InvokeMember("BaseRemove", nonPublicInstanceMethod, null, headers, new object[] { "Authorization" });
    t.InvokeMember("BaseAdd", nonPublicInstanceMethod, null, headers, 
        new object[] { "Authorization", new ArrayList{"Basic " + api_key} });
    
    t.InvokeMember("MakeReadOnly", nonPublicInstanceMethod, null, headers, null);
