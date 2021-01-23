    List<Dictionary<string, string>> result;
    using (var db = new ExampleDB())
    {
        result = db.FormField
                   .Where(r => r.Form_id == 1)
                   .GroupBy(r => r.ResponseId, r => new { r.name, r.value })
                   .AsEnumerable()
                   .Select(g => g.ToDictionary(p => p.name, p => p.value))
                   .ToList();
    }
