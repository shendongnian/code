    var ints = new[] { 1, 2, 3, 5, 7, 8, 10 };
    var result = ints
        // Zip the list with itself shifted 1 to the left (add dummy value at the end)
        // and calculate the difference between each consecutive value.
        .Zip(ints
            .Skip(1)
            .Concat(new[] { int.MaxValue }), (i0, i1) => new { i = i0, diff = i1 - i0 })
        // Reverse because it's far easier keeping track of the group we're at
        .Reverse()
        // Scan through the list, assigning an incremental group number to each
        // consecutive sequence
        .Scan((state, z) => state == null
            ? Tuple.Create(z.i, z.diff, 0)
            : Tuple.Create(z.i, z.diff,
                z.diff > 1 ? state.Item3 + 1 : state.Item3),
            (Tuple<int, int, int>) null) // <-- dummy starting state.
        // Skip the dummy starting state we started the scan with
        .Skip(1)
        // Reverse back
        .Reverse()
        // Group by the group numbers we assigned during the scan
        .GroupBy(t => t.Item3, (i, l) => new { l.First().Item1, l = l.Count() });
