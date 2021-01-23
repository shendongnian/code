    public void Foo (IDictionary<string, IEnumerable<string>> data)
    {
        List<string> item = new List<string>(){ "foo", "bar" };
        data.Add("foo", item);
    }
