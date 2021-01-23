    public List<T> Write<T>(string name, Func<T> factory, Action<T, dynamic> parser)
    {
        var jStr = GetJSONString(name);
        var jArr = JArray.Parse(jStr);
        var specs = new List<T>();
        foreach (dynamic d in jArr)
        {
            var spec = factory();
            parser(spec, d);
            specs.Add(spec);
        }
        return specs;
    }
