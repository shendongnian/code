    public string ToHtmlString()
    {
        var method = typeof(BootstrapTable).GetMethod("ToHtmlStringImpl",
            BindingFlags.Instance | BindingFlags.NonPublic);
        var concreteMethod = method.MakeGenericMethod(_modelType);
        concreteMethod.Invoke(this, new object[] { _dataSet });
    }
    private string ToHtmlStringImpl<T>(IEnumerable<T> data)
    {
        ...
    }
