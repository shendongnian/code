    var re = Request;
    var headers = re.Headers;
    string token = string.Empty;
    StringValues x = default(StringValues);
    if (headers.ContainsKey("Custom"))
    {
       var m = headers.TryGetValue("Custom", out x);
    }
