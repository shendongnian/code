    // Build a set of {Value, Count} pairs using LINQ
    var counts = data
        .GroupBy(v => v)
        .Select(g => new {
            Value = g => Key
        ,   Count = g.Count()
        }).OrderByDescending(p => p.Count);
    // Prepare the output array
    var fivePct = new int[sizeFivePct];
    // i is the index into the output array
    int i = 0;
    // This loop is similar in nature to the counting sort
    foreach (var p in counts) {
        // Add p.Count items equal to p.Value
        for (int n = 0 ; n != p.Count && i != sizeFivePct ; n++) {
            fivePct[i++] = p.Value;
        }
        // If we've got our 5% filled, we're done
        if (i == sizeFivePct) {
            break;
        }
    }
