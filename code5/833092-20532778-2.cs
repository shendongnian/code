    JToken GetParent(JToken token, int parent = 0)
    {
        if (token == null)
            return null;
        if (parent < 0)
            throw new ArgumentOutOfRangeException("Must be positive");
        var skipTokens = new[]
        {
            typeof(JProperty),
        };
        return token.Ancestors()
            .Where(a => skipTokens.All(t => !t.IsInstanceOfType(a)))
            .Skip(parent)
            .FirstOrDefault();
    }
