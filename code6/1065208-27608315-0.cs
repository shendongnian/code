    var topLevel1 = resultRows
        .GroupBy(g => g["CustomerAccountType"])
        .ToDictionary(
            g => g.Key,                                // This is fine since it returns a string
            g => { return g.ToList() as object; });    // Explicitlyreturn this as an object
    topLevel1.Add("somekey", "somevalueorobject");
