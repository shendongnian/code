    IEnumerable<DataSource> GetData()
    {
        return (from element in m_Content.Descendants(Properties.Settings.Default.DataSourceTag)
            select new DataSource
            {
                Provider = Provider.Parse(element.Attribute(Properties.Settings.Default.SpProvider).Value),
                Template = element.Attribute(Properties.Settings.Default.TemplateAttribute).Value,
                Reference = element
            });   // no exception thrown here
    }
    void myMethod1()
    {
        var data = GetData();    // no exception thrown here
        var lst = data.ToList(); // exception might be thrown here!
    }
    void myMethod2()
    {
        var data = GetData();    // no exception thrown here
        foreach (var entry in data) // exception might be thrown here!
        {
            ...
        }
    }
