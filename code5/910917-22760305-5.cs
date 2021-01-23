    // Top of file...
    using System.Globalization;
    // In your method...
    var query =
        from r in dt.AsEnumerable()
        where r.Field<string>("Code") == strCode
        select decimal.Parse(r.Field<string>("Amount"), NumberStyles.Currency);
    return query.Sum().ToString();
