    private double[,,] Mix(double[][,,] normalMaps, double[] weights, double gain)
    {
        var w = normalMaps[0].GetLength(0);
        var h = normalMaps[0].GetLength(1);
        var result = new double[w, h, 3];
        var mapCount = normalMaps.Length;
        var coords = Enumerable.Range(0, w)
            .SelectMany(x => Enumerable.Range(0, h)
            .Select(y => new { x, y }));
        coords.AsParallel().ForAll(c =>
            OneStack(
                c.x,
                c.y,
                mapCount,
                normalMaps,
                weights,
                gain,
                result));
    }
    private static void OneStack(
        int x,
        int y,
        int mapCount,
        double[][,,] normalMaps,
        double[] weights,
        double gain,
        double[,,] result)
    {
        var z0 = 0.0D;
        var z1 = 0.0D;
        var z2 = 0.0D;
        for (var i = 0; i < mapCount; i++)
        {
            var weight = weights[i];
            z0 += normalMaps[i][x, y, 0] * weight;
            z1 += normalMaps[i][x, y, 1] * weight;
            z2 += normalMaps[i][x, y, 2] * weight;
        }
        z0 = Math.Max(-1, Math.Min(1, z0 * gain));
        z1 = Math.Max(-1, Math.Min(1, z1 * gain));
        z2 = Math.Max(-1, Math.Min(1, z2 * gain));
        var norm = Math.Sqrt(z0 * z1 * z2);
        result[x, y, 0] = z0 / norm;
        result[x, y, 1] = z1 / norm;
        result[x, y, 2] = z2 / norm;
    }
