    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string sendRequest(string msg)
    {
        MyClass mc = FromJSON<MyClass>(msg)
        return mc.args[0];
    }
    class MyClass
    {
        internal string[] keys;
        internal string[] args;
    }
    T FromJSON<T>(string json)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        T o = serializer.Deserialize<T>(json);
        return o;
    }
