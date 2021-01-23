    var searchArguments = new Dictionary<string, object>();
    if (ViewBag.Foo != null)
    {
        searchArguments.Add("foo", ViewBag.Foo);
    }
    if (ViewBag.Bar != null)
    {
        searchArguments.Add("bar", ViewBag.Bar);
    }
