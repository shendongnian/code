    var counts = ints1
        .GroupBy(v => v)
        .ToDictionary(g => g.Key, g => g.Count());
    var ok = true;
    foreach (var n in ints2) {
        int c;
        if (counts.TryGetValue(n, out c)) {
            counts[n] = c-1;
        } else {
            ok = false;
            break;
        }
    }
    var res = ok && counts.Values.All(c => c == 0);
