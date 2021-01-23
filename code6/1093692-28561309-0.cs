    public object Convert(...)
    {
        var nullable = (Nullable<DateTime>)value;
        if (nullable.HasValue)
        {
            return nullable.Value.ToShortDateString();
        }
        return String.Empty;
    }
