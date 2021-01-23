    // lukasLansky's solution
    var d = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } }.ToImmutableDictionary();
    // Jon Skeet's solution
    var builder = ImmutableDictionary.CreateBuilder<string, int>();
    builder.Add("a", 1);
    builder.Add("b", 2);   
    var result = builder.ToImmutable();
