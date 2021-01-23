    if (typesToHave.Any(t => b.GetType().IsSubclassOf(t) || b.GetType() == t))
        result.Add(b);
    if (typesToHave.Any(t => c.GetType().IsSubclassOf(t) || c.GetType() == t))
        result.Add(c);
    if (typesToHave.Any(t => d.GetType().IsSubclassOf(t) || d.GetType() == t))
        result.Add(d);
