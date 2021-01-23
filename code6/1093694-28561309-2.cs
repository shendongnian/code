    public object Convert(...)
    {
        var nullable = (Nullable<DateTime>)value;
        if (nullable.HasValue && nullable.Value > DateTime.MinValue)
        {
            return nullable.Value.ToShortDateString();
        }
        return String.Empty;
    }
