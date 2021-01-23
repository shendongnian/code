    var dictionary = products.ToDictionary(
        product => product.Code,
        product => subProductLookup[product.Code]
            .ToDictionary(
                sub => sub.Code,
                sub => valueLookup[sub.Code].First().AddValue));
