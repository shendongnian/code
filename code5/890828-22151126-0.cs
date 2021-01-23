    public byte[] DoSomething(string a = null, string b = null, string c = null)
    {
        var p = new { a, b, c };
        var parts = from property in p.GetType().GetProperties()
                    let value = property.GetValue(p) as string
                    where !string.IsNullOrEmpty(value)
                    select string.Format("{0}={1}", property.Name, value);
        var query = "?" + string.Join("&", parts);
        [...]
    }
