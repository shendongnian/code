    public List<T> Write<T>(string name, Func<T> factory, Action<T, dynamic> parser)
    {
        var jStr = GetJSONString(name);
        var jArr = JArray.Parse(jStr);
        var result = new List<T>();
        foreach (dynamic d in jArr)
        {
            var item = factory();
            parser(item, d);
            result.Add(item);
        }
        return result;
    }
