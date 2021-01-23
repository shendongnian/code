    dic1.Count != dic2.Count ||
    dic1.Keys.Except(dic2.Keys).Any() ||
    !dic1.Join(
        dic2,
        kvp => kvp.Key,
        kvp => kvp.Key,
        (kvp1, kvp2) => new
        {
            l1 = kvp1.Value,
            l2 = kvp2.Value
        })
        .All(a => a.l1.Count == a.l2.Count && !a.l1.Except(a.l2).Any())
