    var type = typeof(System.Web.Util.HttpEncoder);
    var methodInfo = type.GetMethod("UrlEncodeNonAscii", BindingFlags.NonPublic | BindingFlags.Instance, null, new [] { typeof(string), typeof(Encoding) }, null);
    object[] parameters = {fileName, Encoding.UTF8};
    
    var encoder = new System.Web.Util.HttpEncoder();
    
    var encodedFileName = (string) methodInfo.Invoke(encoder, parameters);
