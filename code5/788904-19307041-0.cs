    public static object[] ToObjectArray(this NameValueCollection nvc) {
        List<object> results = new List<object>();
        foreach (string key in nvc.Keys) {
            results.Add(nvc.GetValues(key));
        }
        return results.ToArray();
    }
