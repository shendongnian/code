     // AsEnumerable() pulls us into memory, where we can use EqualityComparers
     var queryWithoutDuplicates = query.AsEnumerable()
         // do a distinct using a comparer based on the key you want to be unique
         .Distinct(EqualityComparers.Create((Item i) => i.LNameByFName))
         .ToList();
