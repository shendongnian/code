    public static double[] stack(double[] input)
    {
        int N = input.Length;        // assuming input = { 1, 2, 3 }
        var z = new double[2 * N];   // z = { 0, 0, 0, 0, 0, 0 }
        input.CopyTo(z, 0);          // z = { 1, 2, 3, 0, 0, 0 }
        input.CopyTo(z, N);          // z = { 1, 2, 3, 1, 2, 3 }
        Array.Reverse(z, N, N);      // z = { 1, 2, 3, 3, 2, 1 }
        return z;
    }
