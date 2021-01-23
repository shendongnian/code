    public int Aperture(int input)
    {
        var binaryString = Convert.ToString(input, 2);
        // The accumulator is an array of ints containing the
        // number of '0' since the last non-'0' character.
        var segments = binaryString.Aggregate(
            new [] { 0 },
            (acc, c) =>
                c == '0'
                // Case 0: increment last segment's count, leave rest as is.
                ? acc
                    .Take(acc.Length - 1)
                    .Concat(new [] { acc[acc.Length - 1] + 1 })
                    .ToArray()
                // Case 1: append new segment with zero count.
                : acc
                    .Concat(new [] { 0 })
                    .ToArray()
        );
        return segments
            // If last segment count is non-zero, it was not
            // closed with a '1' and we want to exclude it.
            .Take(segments.Length - 1)
            .Max();
    }
    [TestMethod]
    public void ApertureTest()
    {
        Assert.AreEqual(2, Aperture(9));   // 1001,       Segments: 0, 2, 0
        Assert.AreEqual(4, Aperture(529)); // 1000010001, Segments: 0, 4, 3, 0
        Assert.AreEqual(1, Aperture(20));  // 10100,      Segments: 0, 1, 2
        Assert.AreEqual(0, Aperture(15));  // 1111,       Segments: 0, 0, 0, 0
    }
