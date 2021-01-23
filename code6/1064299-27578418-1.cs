    private static readonly IEnumerable<Store> _myStores = new[]
    {
        new Store {Footage = 100, MobileEnd = "XYZ", SizeCode = SizeCode.Small},
        new Store {Footage = 200, MobileEnd = "XYZ", SizeCode = SizeCode.Medium},
        new Store {Footage = 300, MobileEnd = "XYZ", SizeCode = SizeCode.Large},
        new Store {Footage = 150, MobileEnd = "ABC", SizeCode = SizeCode.Small},
        new Store {Footage = 250, MobileEnd = "ABC", SizeCode = SizeCode.Medium},
        new Store {Footage = 350, MobileEnd = "ABC", SizeCode = SizeCode.Large},
    };
    private static IEnumerable<Store> ApplyAndPredicates(IEnumerable<Func<Store, bool>> predicates)
    {
        var filteredStores = _myStores;
        foreach (var predicate in predicates)
        {
            filteredStores = filteredStores.Where(predicate);
        }
        return filteredStores;
    }
    public static List<Store> MeetCriteria(List<Store> entities, int? footage = null, string mobileEnd = null, SizeCode? sizeCode = null)
    {
        var predicates = new List<Func<Store, bool>>();
        if (footage.HasValue)
        {
            predicates.Add(s => s.Footage == footage.Value);
        }
        if (mobileEnd != null)
        {
            predicates.Add(s => s.MobileEnd == mobileEnd);
        }
        if (sizeCode != null)
        {
            predicates.Add(s => s.SizeCode == sizeCode);
        }
        return ApplyAndPredicates(predicates).ToList();
    }
