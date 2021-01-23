    using System.Globalization;
    string a;
    var query = from r in dt.AsEnumerable()
                where r.Field<string>("Code") == strCode
                select decimal.Parse(r.Field<string>("Amount"), NumberStyles.Currency);
    if (query.Count() == 0)
    {
        a = "0";
    }
    else
    {
        foreach (var item in query)
        {
            a = item.ToString();
        }
    }
    return a;
