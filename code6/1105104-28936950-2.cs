    int? TryConvertInt32(obj value)
    {
        try { return Convert.ToInt32(value); } catch { return default(int?); }
    }
    var mins =
        from row in table.AsEnumerable()
        select row.ItemArray.Select(v => TryConvertInt32(v) ?? 0).Min();
