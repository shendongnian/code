    var first = new Random(100);
    // gain access to private seed array of Random
    var seedArrayInfo = typeof(Random).GetField("SeedArray", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    var seedArray = seedArrayInfo.GetValue(first) as int[];
    var other = new Random(200); // seed doesn't matter!
    var seedArrayCopy = seedArray.ToArray(); // we need to copy since otherwise they share the array!
    seedArrayInfo.SetValue(other, seedArrayCopy);
    for (var i = 10; i < 1000; ++i)
    {
        var v1 = first.Next(i);
        var v2 = other.Next(i);
        Debug.Assert(v1 == v2);
    }
