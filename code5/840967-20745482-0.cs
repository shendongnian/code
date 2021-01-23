    public string ToUrlString(this Example example)
    {
        return "property1=" +  HttpServerUtility.UrlEncode(example.Property1)
           + "&property2=" + HttpServerUtility.UrlEncode(example.Property2.ToString())
           + "&property3=" + HttpServerUtility.UrlEncode(example.Property3.ToString());
    }
