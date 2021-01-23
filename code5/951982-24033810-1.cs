    // lukasLansky's solution
    var d = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } }.ToImmutableDictionary();
    // Jon Skeet's solution
    var result = ImmutableDictionary.CreateBuilder<string, int>()
                                    .Add("a", 1)
                                    .Add("b", 2)
                                    .ToImmutable();
