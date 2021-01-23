    var lookup = Enumerable
        .Range(1, 20)
        .Select(i => new Product { Title = "Product " + i, StyleID = i })
        .Select(
            o => new
                 {
                     Text = o.MemberWithAttribute<TextFieldAttribute>(),
                     Value = o.MemberWithAttribute<ValueFieldAttribute>()
                 })
        .Where(o => o.Text != null && o.Value != null)
        .ToDictionary(o => o.Text, o => o.Value);
    foreach (var key in lookup.Keys)
        Console.WriteLine("{0}: {1}", key, lookup[key]);
