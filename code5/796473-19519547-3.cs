    class Item
    {
        internal string Value { get; set; }
        internal string Qux { get; set; }
        internal string Quux { get; set; }
    }
    var query = from i in list
                group i by new { i.Value, i.Qux } into g // Note: no Quux, no primary key, just what's necessary
                orderby g.Count() descending, g.Key.Value
                select new { // [1]
                    Value = g.Key.Value,
                    Qux = g.Key.Qux,
                    // Quux?
                }
