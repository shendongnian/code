    string[] postedTillNames = { "A", "C", "E"};
    var result = (from s in Stores
                 join a in Assets on s.ID equals a.StoreID
                 group new { A = a, S = s } by a.StoreID into assetsGroup
                 where !postedTillNames.Any(p => !assetsGroup.Select(g => g.A.Name)
                                                             .Contains(p))
                 select assetsGroup.First().S).ToList();
