    var tempA = new HashSet<int>(inputA.Select(item => item.Id));
    var tempB = new HashSet<int>(inputB.Select(item => item.Id));
    var resultA = new List<Category>(inputA.Count);
    var resultB = new List<Category>(inputB.Count);
    foreach (var value in inputA)
        if (tempB.Contains(value.Id))
            resultA.Add(value);
    foreach (var value in inputB)
        if (!tempA.Contains(value.Id))
            resultB.Add(value);
    resultA.TrimExcess();
    resultB.TrimExcess();
    // and if needed:
    inputA = resultA;
    inputB = resultB;
