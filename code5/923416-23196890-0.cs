    public static double[] ConvertDoubleArray(Array arr) {
        if (arr.Rank != 1) throw new ArgumentException();
        var retval = new double[arr.GetLength(0)];
        for (int ix = arr.GetLowerBound(0); ix <= arr.GetUpperBound(0); ++ix)
            retval[ix - arr.GetLowerBound(0)] = (double)arr.GetValue(ix);
        return retval;
    }
