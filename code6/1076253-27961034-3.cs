    if (!string.IsNullOrWhiteSpace(node.Value))
    {
        DateTime date;
        if (DateTime.TryParseExact(node.Value.Trim(),
            @"yyyy-MM-dd\THH:mm:ss", 
            CultureInfo.InvariantCulture, 
            DateTimeStyles.AssumeUniversal, 
            out date)
        {
            node.Value = date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
