    public static class NameValueCollectionExtensions
    {
        public static NameValueCollection AddValue(this NameValueCollection headers, string key, string value)
        {
            Type t = headers.GetType();
            t.InvokeMember("MakeReadWrite", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, headers, null);
            t.InvokeMember("InvalidateCachedArrays", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, headers, null);
            t.InvokeMember("BaseAdd", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, headers, new object[] { key, new System.Collections.ArrayList() { value } });
            t.InvokeMember("MakeReadOnly", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, headers, null);
            return headers;
        }
    }
