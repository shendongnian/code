    List<KeyvaluePair<DateTime, ObjectA>> collectionWithDates = collection
        .Select
        (
            objectA => new KeyValuePair<DateTime, ObjectA>
            (
                objectA
                    .SelectMany(a => a.ObjectBCollection)
                    .SelectMany(b => b.ObjectCCollection)
                    .OrderBy(c => c.Date).ThenBy(c => (int)c.Type)
                    .Last()
                    .Date,
                objectA
            )
        )
        .ToList();
