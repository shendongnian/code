    public void Foo (IDictionary<string, IEnumerable<string>> data)
    {
        List<string> item = new List<string>(){ "foo", "bar", "baz" };
        data.Add("key", item);
    }
