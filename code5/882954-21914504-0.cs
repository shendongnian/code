    public static double[] DivvyUp(double total, uint count)
    {
        var parts = new double[count];
        for (var i = 0; i < count; ++i)
        {
            var part = Math.Truncate((100d * total) / (count - i)) / 100d;
            parts[i] = part;
            total -= part;
        }
        return parts;
    }
