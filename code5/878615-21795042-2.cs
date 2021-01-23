    public string ToHtmlString()
    {
        dynamic data = _dataSet;
        ToHtmlString(data);
    }
    private string ToHtmlString<T>(IEnumerable<T> data)
    {
        ...
    }
