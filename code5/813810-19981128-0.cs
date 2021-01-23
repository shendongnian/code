    var arr1 = new[] { "A", "B", "C", "D" };
    var arr2 = new[] { "A", "D" };
    var arr3 = new[] { "A", "B", };
    var arr4 = new[] { "C", "D" };
    var arr5 = new[] { "B", "C", "D" };
    var arr6 = new[] { "B", "A", };
    var results = new List<IEnumerable<string>>() { arr1, arr2, arr3, arr4, arr5, arr6 }
                                    .Select(arr => arr.Distinct())
                                    .SelectMany(s => s)
                                    .GroupBy(s => s)
                                    .Select(grp => new { Text = grp.Key, Count = grp.Count() })
                                    .OrderByDescending(t => t.Count)
                                    .ToList();
